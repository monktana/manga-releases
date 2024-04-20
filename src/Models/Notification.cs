using System.Text.Json.Serialization;

namespace Manga;

public class Notification
{
    [JsonPropertyName("content")]
    public string Content { get; set;}
}