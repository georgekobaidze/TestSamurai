using NUnit.Framework;

namespace TestSamurai.NUnitTests;

[TestFixture]
public class TextFormatterTests
{
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
}
