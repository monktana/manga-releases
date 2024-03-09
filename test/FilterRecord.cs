namespace test;

public class FilterRecord_ToString
{
    [Fact]
    public void ToString_Month_success() {
        var filterRecord = new FilterRecord(5, new DateOnly(2022, 8, 10));
        var result = filterRecord.ToString();

        Assert.Equal("?itemsPerPage=5&date[after]=2022-8-10", result);
    }
    [Fact]
    public void ToString_Day_success() {
        var filterRecord = new FilterRecord(5, new DateOnly(2022, 10, 1));
        var result = filterRecord.ToString();

        Assert.Equal("?itemsPerPage=5&date[after]=2022-10-1", result);
    }
}