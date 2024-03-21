namespace Manga;

public sealed class MangaOptions
{
  public List<int> Ids { get; set; } = [];

  public string EndpointUrl { get; set; } = string.Empty;
};