namespace Manga;

/// <summary>
/// Klasse, zur Kapselung der API-Konfiguration in den Appsettings.
/// </summary>
public sealed class MangaOptions
{
  /// <summary>
  /// Liste der relevanten Mangaserien.
  /// </summary>
  public List<int> Ids { get; set; } = [];

  /// <summary>
  /// BaseURL der API zur Abfrage der Daten.
  /// </summary>
  public string BaseURL { get; set; } = string.Empty;
};

/// <summary>
/// Informationen über den Publisher einer Mangareihe
/// </summary>
/// <param name="Id">Die ID des Datensatzes</param>
/// <param name="Name">Der Name des Publishers</param>
public record Publisher(
   int Id,
   string? Name
);

/// <summary>
/// Informationen über die Mangareihe
/// </summary>
/// <param name="Id">Die ID des Datensatzes</param>
/// <param name="Title">Der Name der Mangareihe</param>
/// <param name="Publishers">Der Publisher der Mangareihe</param>
/// <param name="Print">Ist die Mangereihe in print veröffentlicht</param>
/// <param name="Digital">Ist die Mangereihe digital veröffentlicht</param>
public record Edition(
  int Id,
  string? Title,
  Publisher[]? Publishers,
  bool Print,
  bool Digital
);

/// <summary>
/// Informationen über ein Mangavolume
/// </summary>
/// <param name="Id">Die ID des Datensatzes</param>
/// <param name="Number">Die Nummer des Volumes</param>
/// <param name="LastNumber">Die Nummer des letzten Volumes der Mangareihe</param>
/// <param name="Arragement"></param>
/// <param name="Pages">Die Seitenanzahl des Mangavolumes</param>
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