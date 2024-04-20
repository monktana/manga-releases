namespace Manga;

/// <summary>
/// Serviceklasse für den Zugriff auf die API von Mangapassion.
/// </summary>
/// <remarks>
/// https://www.manga-passion.de/
/// </remarks>
/// <param name="client">Insatz eines Httpclient</param>
public class MangaPassionService(HttpClient client)
{
  /// <summary>
  /// Fragt die zuletzt veröffentlichten Mangavolumes an.
  /// Die Menge und der Zeitraum wird vom optionalen FilterRecord bestimmt.
  /// </summary>
  /// <param name="filter">Filter, um die Menge und den Zeitraum der angefragten Daten zu bestimmen.</param>
  /// <returns>Liste von Mangavolumes</returns>
  public async Task<List<MangaVolume>> GetMangaVolumes(FilterRecord? filter)
  {
    var mangaVolumes = await client.GetFromJsonAsync<List<MangaVolume>>("volumes" + filter?.ToString());

    return mangaVolumes?.Where(volume => volume.Number != null).ToList() ?? [];
  }
}