using NUnit.Framework;

namespace TestSamurai.NUnitTests;

[TestFixture]
public class FizzBuzzTests
{
    [Test]
    public void GetOutput_DivisibleByThreeOnly_StartsWithFizz()
    {
        var number = 3;
        var result = FizzBuzz.GetOutput(number);

        Assert.That(result, Is.EqualTo("Fizz"));
    }

    [Test]
    public void GetOutput_DivisibleByFiveOnly_EndsWithBuzz()
    {
        var number = 5;
        var result = FizzBuzz.GetOutput(number);

        Assert.That(result, Is.EqualTo("Buzz"));
    }

    [Test]
    public void GetOutput_DivisibleByThreeAndFive_ReturnsFizzBuzz()
    {
        var number = 15;
        var result = FizzBuzz.GetOutput(number);

        Assert.That(result, Is.EqualTo("FizzBuzz"));
    }

    [Test]
    public void GetOutput_NonDivisibleByThreeOrFive_ReturnsNumber()
    {
        var number = 7;
        var result = FizzBuzz.GetOutput(number);

        Assert.That(result, Is.EqualTo(number.ToString()));
    }
}
