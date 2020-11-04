

using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests {

    [TestFixture]
    class DemeritPointsCalculatorTests {

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowArgumentOutOfRangeException(int speed) {

            var demeritPointsCalculator = new DemeritPointsCalculator();

            Assert.That(() => demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        
        [Test]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(65)]
        public void CalculateDemeritPoints_WhenSpeedIsLessThenSpeedLimit_ReturnZero(int speed) {

            var demeritPointsCalculator = new DemeritPointsCalculator();

            var result = demeritPointsCalculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase(70, 1)]
        [TestCase(300, 47)]
        public void CalculateDemeritPoints_SpeedIsGreaterThenSpeedLimit_ReturnDemeritPoints(int speed, int demeritPoints) {

            var demeritPointsCalculator = new DemeritPointsCalculator();

            var result = demeritPointsCalculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(demeritPoints));
        }
    }
}
