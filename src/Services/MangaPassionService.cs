namespace Manga;

/// <summary>
/// 
/// </summary>
/// <param name="client"></param>
/// <param name="logger"></param>
public class MangaPassionService(HttpClient client)
{
  /// <summary>
  /// Requests Mangareleases based on the provided filterquery.
  /// </summary>
  /// <param name="filter">The query to filter the request</param>
  /// <returns>List of Manga</returns>
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