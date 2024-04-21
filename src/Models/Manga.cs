using System.Text.Json.Serialization;

namespace MangaReleases.Models;

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
    public string BaseUrl { get; set; } = string.Empty;
};

/// <summary>
/// Informationen über den Publisher einer Mangareihe
/// </summary>
public record Publisher
{
    [JsonPropertyName("id")] public int Id { get; init; }

    [JsonPropertyName("name")] public string? Name { get; init; }
};

/// <summary>
/// Informationen über die Mangareihe
/// </summary>
public record Edition
{
    [JsonPropertyName("id")] public int Id { get; init; }

    [JsonPropertyName("title")] public string? Title { get; init; }

    [JsonPropertyName("publishers")] public Publisher[]? Publishers { get; init; }

    [JsonPropertyName("digital")] public bool Digital { get; init; }

    [JsonPropertyName("print")] public bool Print { get; init; }
}

/// <summary>
/// Informationen über ein Mangavolume
/// </summary>
public record class MangaVolume
{
    [JsonPropertyName("id")] public int Id { get; init; }

    [JsonPropertyName("number")] public int? Number { get; init; }

    [JsonPropertyName("last_number")] public int? LastNumber { get; init; }

    [JsonPropertyName("arragement")] public int? Arragement { get; init; }

    [JsonPropertyName("pages")] public int? Pages { get; init; }

    [JsonPropertyName("year")] public int? Year { get; init; }

    [JsonPropertyName("month")] public int? Month { get; init; }

    [JsonPropertyName("day")] public int? Day { get; init; }

    [JsonPropertyName("date")] public DateTime? Date { get; init; }

    [JsonPropertyName("title")] public string Title { get; init; }

    [JsonPropertyName("cover")] public string Cover { get; init; }
    
    [JsonPropertyName("edition")] public Edition? Edition { get; init; }
}