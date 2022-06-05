using NUnit.Framework;
using TestSamurai.SimpleScenarios;

namespace TestSamurai.NUnitTests.SimpleScenarios;

[TestFixture]
public class TextFormatterTests
{
    private TextFormatter _formatter;

    [SetUp]
    public void SetUp() => _formatter = new TextFormatter();

    [Test]
    public void MakeBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
    {
        var formatter = new TextFormatter();
        var result = formatter.MakeBold("Test");

        // Specific
        Assert.That(result, Is.EqualTo("<strong>Test</strong>"));

        //General
        Assert.That(result, Does.StartWith("<strong>"));
        Assert.That(result, Does.EndWith("</strong>"));
        Assert.That(result, Does.Contain("Test"));
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void MakeBold_InvalidError_ThrowArgumentNullException(string text)
        => Assert.That(() => _formatter.MakeBold(text), Throws.ArgumentNullException);
}
