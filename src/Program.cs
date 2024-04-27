using MangaReleases.Models;
using MangaReleases.Services;

var builder = WebApplication.CreateBuilder(args);

MangaOptions options = new();
builder.Configuration.GetSection(nameof(MangaOptions))
    .Bind(options);

builder.Services.AddHttpClient<MangaPassionService>(
  client =>
  {
    client.BaseAddress = new Uri(options.BaseUrl);
  });

builder.Services.AddHttpClient<INotificationService, DiscordNotificationService>(
  client =>
  {
    client.BaseAddress = new Uri(builder.Configuration.GetConnectionString("Discord")!);
  });

var app = builder.Build();

app.MapGet("/update", async (MangaPassionService mangaService, INotificationService notificationService) =>
{
  var mangas = await mangaService.GetMangaVolumes(new FilterRecord(50, DateTime.Now.AddDays(-1)));
  
  var result = mangas.Where(manga => options.Ids.Contains(manga.Id)).ToList();
  var notifications = result.Select(volume => new Notification {Content = $"New Release: {volume.Edition!.Title}"});
  await notificationService.Send(notifications);
  
  return Results.Ok(result);
});

app.Run();
