namespace Manga
{
  /// <summary>
  /// Informationen über den Publisher einer Mangareihe
  /// </summary>
  /// <param name="ID"></param>
  /// <param name="Name">Der Name des Publishers</param>
  public record class Publisher(
     int ID,
     string? Name
  );

  /// <summary>
  /// Informationen über die Mangareihe
  /// </summary>
  /// <param name="ID"></param>
  /// <param name="Title">Der Name der Mangareihe</param>
  /// <param name="Publishers"></param>
  /// <param name="Print">Ist die Mangereihe in print veröffentlicht</param>
  /// <param name="Digital">Ist die Mangereihe digital veröffentlicht</param>
  public record class Edition(
    int ID,
    string? Title,
    Publisher[]? Publishers,
    bool Print,
    bool Digital
  );

  /// <summary>
  /// Informationen über ein Mangavolume
  /// </summary>
  /// <param name="Id"></param>
  /// <param name="Number">Die Nummer des Volumes</param>
  /// <param name="LastNumber">Die Nummer des letzten Volumes der Mangareihe</param>
  /// <param name="Arragement"></param>
  /// <param name="Pages"></param>
  /// <param name="Year">Das Jahr der Veröffentlichung</param>
  /// <param name="Month">Die Monat der Veröffentlichung</param>
  /// <param name="Day">Der Tag der Veröffentlichung</param>
  /// <param name="Date">Das Veröffentlichungsdatum</param>
  /// <param name="Title">Die Art des Volumes</param>
  /// <param name="Cover">Der Link zum Cover</param>
  /// <param name="Edition">Informationen über die Mangareihe</param>
  public record class MangaVolume(
    int Id,
    int? Number,
    int? LastNumber,
    int? Arragement,
    int? Pages,
    int? Year,
    int? Month,
    int? Day,
    DateTime? Date,
    string? Title,
    string? Cover,
    Edition? Edition
  );

  /// <summary>
  /// 
  /// </summary>
  /// <param name="client"></param>
  public class MangaService(HttpClient client)
  {
    public async Task<List<MangaVolume>> GetMangaVolumes(FilterRecord? filter)
    {
      try
      {
        List<MangaVolume>? mangaVolumes = await client.GetFromJsonAsync<List<MangaVolume>>("volumes" + filter?.ToString());

        return mangaVolumes?.Where(volume => volume.Number != null).ToList() ?? [];
      }
      catch (System.Exception)
      {
        throw;
      }
    }
  }
}