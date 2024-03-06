namespace Manga
{
  public record class Publisher(
     int ID,
     string? Name
  );
  public class Edition
  {
    public int ID { get; set; }
    public string? Title { get; set; }
    public Publisher[]? Publishers { get; set; }
    public bool Print { get; set; }
    public bool Digital { get; set; }

  }
  public class Manga
  {
    public int Id { get; set; }
    public int? Number { get; set; }
    public int? LastNumber { get; set; }
    public int? Arragement { get; set; }
    public int? Pages { get; set; }
    public int? Year { get; set; }
    public int? Month { get; set; }
    public int? Day { get; set; }
    public DateTime? Date { get; set; }
    public string? Title { get; set; }
    public string? Cover { get; set; }
    public Edition? Edition {get; set;}
  }

  public class MangaService(HttpClient client)
  {
    
    public async Task<List<Manga>> GetMangaVolumes(string? query)
    {
      try
      {
        List<Manga>? mangaVolumes = await client.GetFromJsonAsync<List<Manga>>(query);
        return mangaVolumes ?? [];
      }
      catch (System.Exception)
      {
        throw;
      }
    }
  }
}