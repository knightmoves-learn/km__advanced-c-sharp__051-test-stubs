using System.Reflection;

public class LessonTests
{
    private static string Lesson50FilePath = @"../../../Lesson50Tests/Math.Tests.cs";
    private string Lesson50Content = File.ReadAllText(Lesson50FilePath);
    private readonly string[] _requiredTestMethods =
    {
        "ShouldReturnCorrectRomanNumeralFor1",
        "ShouldReturnCorrectRomanNumeralFor483",
        "ShouldReturnNonEmptyStringWhenNumberIsInRange",
        "ShouldThrowArgumentOutOfRangeExceptionWhenIntegerIsOutOfRange"
    };

    [Fact]
    public void Lesson50MathTestsShouldPass()
    {
        var testAssembly = Assembly.GetExecutingAssembly();
        var mathTestsClass = testAssembly.GetTypes()
            .FirstOrDefault(t => t.Name == "MathTests");

        Assert.NotNull(mathTestsClass);

        var instance = Activator.CreateInstance(mathTestsClass);

        foreach (var requiredMethodName in _requiredTestMethods)
        {
            var testMethod = mathTestsClass.GetMethod(requiredMethodName);
            Assert.True(testMethod != null, $"Method {requiredMethodName} not found in MathTests class");

            try
            {
                testMethod.Invoke(instance, null);
            }
            catch (TargetInvocationException ex)
            {
                Assert.Fail($"Test {requiredMethodName} failed: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
    }

    // [Fact]
    // public void Lesson50MathTestsShouldContainExpectedAssertions()
    // {
    //     Assert.True(Lesson50Content.Contains("Assert.Equal(\"I\", result);"),
    //         $"The file {Lesson50FilePath} does not contain \"Assert.Equal(\"I\", result);\".");
    //     Assert.True(Lesson50Content.Contains("Assert.Equal(\"CDLXXXIII\", result);"),
    //         $"The file {Lesson50FilePath} does not contain \"Assert.Equal(\"CDLXXXIII\", result);\".");
    //     Assert.True(Lesson50Content.Contains("Assert.Equal(\"\", result);"),
    //         $"The file {Lesson50FilePath} does not contain \"Assert.Equal(\"\", result);\".");
    // }

    // [Fact]
    // public void Lesson50MathTestsShouldSetupMathServiceInConstructor()
    // {
    //     Assert.True(Lesson50Content.Contains("mathService = new();"),
    //         $"The file {Lesson50FilePath} does not contain \"mathService = new();\" in the constructor.");
    //     Assert.True(!Lesson50Content.Contains("var mathService = new MathService();"),
    //         $"The file {Lesson50FilePath} should not contain \"var mathService = new MathService();\" in test methods.");
    // }

    // [Fact]
    // public void Lesson50MathTestsShouldContainDisposeMethod()
    // {
    //     Assert.True(Lesson50Content.Contains("public void Dispose()"),
    //         $"The file {Lesson50FilePath} does not contain a Dispose method.");
    //     Assert.True(Lesson50Content.Contains("mathService = null;"),
    //         $"The Dispose method in {Lesson50FilePath} does not set mathService to null.");
    //     Assert.True(Lesson50Content.Contains("randomInRangeInt = null;"),
    //         $"The Dispose method in {Lesson50FilePath} does not set randomInRangeInt to null.");
    // }

    [Fact]
    public void Lesson50MathTestsShouldCheckForArgumentOutOfRange()
    {
        Assert.True(Lesson50Content.Contains("Assert.Throws<ArgumentOutOfRangeException>"),
            $"The file {Lesson50FilePath} does not call Assert.Throws<ArgumentOutOfRangeException>.");
    }
}