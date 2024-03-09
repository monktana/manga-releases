var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<Manga.MangaService>(
    client =>
    {
        client.BaseAddress = new Uri("https://api.manga-passion.de");
    });

var app = builder.Build();

app.MapGet("/", async (Manga.MangaService s) => await s.GetMangaVolumes(new FilterRecord(100, DateTime.Now.AddDays(-1))));

app.Run();
