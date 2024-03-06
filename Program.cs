var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<Manga.MangaService>(
    client =>
    {
        client.BaseAddress = new Uri("https://api.manga-passion.de");
    });

var app = builder.Build();

// app.MapGet("/", () => "Snasen!");
app.MapGet("/", async (Manga.MangaService s) => await s.GetMangaVolumes("volumes?itemsPerPage=48&page=1"));

app.Run();
