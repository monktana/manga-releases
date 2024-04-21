using MangaReleases.Models;

namespace MangaReleases.UnitTests;

public class FilterRecordTests
{
    [Fact]
    public void ToString_FormatsAMonthWithTwoCharacters() {
        var filterRecord = new FilterRecord(5, new DateTime(2022, 8, 11));
        var result = filterRecord.ToString();

        Assert.Equal("?itemsPerPage=5&date[after]=2022-8-11&date[strictly_before]=2022-8-12", result);
    }

    [Fact]
    public void ToString_FormatsADayWithTwoCharacters() {
        var filterRecord = new FilterRecord(5, new DateTime(2022, 11, 3));
        var result = filterRecord.ToString();

        Assert.Equal("?itemsPerPage=5&date[after]=2022-11-3&date[strictly_before]=2022-11-4", result);
    }
}