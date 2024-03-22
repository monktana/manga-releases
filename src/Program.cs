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


var app = builder.Build();

app.MapGet("/", async (MangaPassionService s) => await s.GetMangaVolumes(new FilterRecord(100, DateTime.Now.AddDays(-1))));

app.MapGet("/latest", async (MangaPassionService s) =>
{
  var mangas = await s.GetMangaVolumes(new FilterRecord(100, DateTime.Now.AddDays(-1)));

  return mangas?.Where(manga => options.Ids.Contains(manga.Id)).ToList() ?? [];
});

app.Run();
