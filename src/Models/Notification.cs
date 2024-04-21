using System.Text.Json.Serialization;

namespace MangaReleases.Models;

public class Notification
{
    [JsonPropertyName("content")] public string Content { get; set; }
}