public class FilterRecord(int itemsPerPage, DateTime date)
{
  private int _itemsPerPage = itemsPerPage;
  private DateTime _dateAfter = date;
  private DateTime _dateBefore = date.AddDays(1);

  public override string ToString()
  {
    return "?itemsPerPage=" + _itemsPerPage + "&date[after]=" + _dateAfter.ToString("yyyy-M-d") + "&date[strictly_before]=" + _dateBefore.ToString("yyyy-M-d");
  }
}