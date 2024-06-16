using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class DemeritPointsCalculatorTests
    {
        private const int SpeedLimit = 65;
        private const int MaxSpeed = 300;
        private readonly DemeritPointsCalculator _calculator = new DemeritPointsCalculator();
        [Test]
        public void CalculateDemeritPoints_WhenCalled_SpeedOutOfRange()
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.CalculateDemeritPoints(-10), "The argument must have a positive value!");
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.CalculateDemeritPoints(1000), "The argument must be lower than 300!");
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        public void CalculateDemeritPoints_WhenCalled_SpeedWithinSpeedLimit(int speed, int expectedValue)
        {
            Assert.That(_calculator.CalculateDemeritPoints(speed), Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        [TestCase(80, 3)]
        public void CalculateDemeritPoints_WhenCalled_SpeedOverSpeedLimit(int speed, int expectedValue)
        {
            Assert.That(_calculator.CalculateDemeritPoints(speed), Is.EqualTo(expectedValue));
        }
    }
}
