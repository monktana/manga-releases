using System.Text;
using System.Text.Json;
using Manga;

var builder = WebApplication.CreateBuilder(args);

MangaOptions options = new();
builder.Configuration.GetSection(nameof(MangaOptions))
    .Bind(options);

builder.Services.AddHttpClient<MangaPassionService>(
  client =>
  {
    client.BaseAddress = new Uri(options.BaseURL);
  });

// builder.Services.AddScoped<INotificationService, DiscordNotificationService>();

builder.Services.AddHttpClient<INotificationService, DiscordNotificationService>(
  client =>
  {
    client.BaseAddress = new Uri("https://discord.com");
  });

var app = builder.Build();

app.MapGet("/", async (MangaPassionService s) => await s.GetMangaVolumes(new FilterRecord(100, DateTime.Now.AddDays(-1))));

app.MapGet("/latest", async (MangaPassionService s, INotificationService notificationService) =>
{
  var mangas = await s.GetMangaVolumes(new FilterRecord(3, DateTime.Now.AddDays(-1)));

  // var result = mangas.Where(manga => options.Ids.Contains(manga.Id)).ToList();
  var notifications = mangas.Select(volume => new Notification {Content = $"New Release: {volume.Edition!.Title}"});

  await notificationService.Send(notifications);
  
  return mangas;
});

app.Run();
