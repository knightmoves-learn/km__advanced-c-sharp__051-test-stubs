using HomeEnergyApi.Services;

public class MathTests
{
    private MathService? mathService;
    private int? randomInRangeInt;

    public MathTests()
    {
        mathService = new MathService();
        randomInRangeInt = new Random().Next(1, 3999);
    }

    public void Dispose()
    {
        mathService = null;
        randomInRangeInt = null;
    }

    [Fact]
    public void ShouldReturnCorrectRomanNumeralFor1()
    {
        var result = mathService.ConvertToRomanNumeral(1);
        Assert.Equal("I", result);
    }

    [Fact]
    public void ShouldReturnCorrectRomanNumeralFor483()
    {
        var result = mathService.ConvertToRomanNumeral(483);
        Assert.Equal("CDLXXXIII", result);
    }

    [Fact]
    public void ShouldReturnNonEmptyStringWhenNumberIsInRange()
    {
        var result = mathService.ConvertToRomanNumeral(randomInRangeInt);
        Assert.True(result != "", result);
    }

    [Fact]
    public void ShouldThrowArgumentOutOfRangeExceptionWhenIntegerIsOutOfRange()
    {
        // var result = mathService.ConvertToRomanNumeral(-1);
        // Assert.Equal("", result);
        Assert.Throws<ArgumentOutOfRangeException>(() => { mathService.ConvertToRomanNumeral(-1); });
    }
}