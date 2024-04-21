namespace MangaReleases.Models;

public class FilterRecord(int itemsPerPage, DateTime date)
{
  private readonly DateTime _dateBefore = date.AddDays(1);

  public override string ToString()
  {
    return "?itemsPerPage=" + itemsPerPage + "&date[after]=" + date.ToString("yyyy-M-d") + "&date[strictly_before]=" + _dateBefore.ToString("yyyy-M-d");
  }
}