public class FilterRecord(int itemsPerPage, DateOnly dateAfter)
{
  private int _itemsPerPage = itemsPerPage;
  private DateOnly _dateAfter = dateAfter;

  public override string ToString()
  {
    return "?itemsPerPage=" + _itemsPerPage + "&date[after]=" + _dateAfter.ToString("yyyy-M-d");
  }
}