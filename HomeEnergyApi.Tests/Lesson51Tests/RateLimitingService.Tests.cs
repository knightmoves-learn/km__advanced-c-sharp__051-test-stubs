using HomeEnergyApi.Services;
using HomeEnergyApi.Wrapper;

public class RateLimitingServiceTests
{
    private DateTime currentDateTime;
    private StubDateTimeWrapper stubDateTime;
    private RateLimitingService? rateLimitingService;
    public RateLimitingServiceTests()
    {
        currentDateTime = DateTime.UtcNow;
        stubDateTime = new StubDateTimeWrapper(currentDateTime);
        rateLimitingService = new RateLimitingService(stubDateTime);
    }

    [Fact]
    public void ShouldReturnTrueWhenItIsWeekend()
    {
        var initialTime = DateTime.Parse("2000-01-01 01:01:01");
        stubDateTime.SetUp(initialTime);
        var result = rateLimitingService.IsWeekend();

        Assert.True(result);
    }

    [Fact]
    public void ShouldReturnFalseWhenItIsWeekday()
    {
        var initialTime = DateTime.Parse("2000-01-03 01:01:01");
        stubDateTime.SetUp(initialTime);
        var result = rateLimitingService.IsWeekend();

        Assert.False(result);
    }
}

public class StubDateTimeWrapper : IDateTimeWrapper
{
    private DateTime dateTime;

    public StubDateTimeWrapper(DateTime dateTime)
    {
        this.dateTime = dateTime;
    }

    public void SetUp(DateTime dateTime)
    {
        this.dateTime = dateTime;
    }

    public DateTime UtcNow()
    {
        return dateTime;
    }
}