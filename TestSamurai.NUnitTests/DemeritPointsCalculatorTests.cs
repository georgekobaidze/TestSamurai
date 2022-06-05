using System;
using NUnit.Framework;

namespace TestSamurai.NUnitTests;

[TestFixture]
public class DemeritPointsCalculatorTests
{
    private DemeritPointsCalculator _demeritPointsCalculator;

    [SetUp]
    public void SetUp() => _demeritPointsCalculator = new DemeritPointsCalculator();

    [Test]
    public void CalculateDemeritPoints_SpeedIsLessThanZero_ThrowsArgumentOutOfRangeException()
    {
        var speed = -1;
        Assert.Throws<ArgumentOutOfRangeException>(() => _demeritPointsCalculator.CalculateDemeritPoints(speed));
    }

    [Test]
    [TestCase(0, 0)]
    [TestCase(64, 0)]
    [TestCase(65, 0)]
    [TestCase(69, 0)]
    [TestCase(75, 2)]
    public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoint(int speed, int demeritPoint)
    {
        var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);
        Assert.That(result, Is.EqualTo(demeritPoint));
    }
}
