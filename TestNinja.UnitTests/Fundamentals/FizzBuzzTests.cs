using NUnit.Framework;
using NUnit.Framework.Internal;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests {

    [TestFixture]
    class FizzBuzzTests {

        [Test]
        public void GetOutput_WhenNumberDividedByThreeAndFive_ReturnFizzBuzz() {

            var result = FizzBuzz.GetOutput(15);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_WhenNumberDividedByThree_ReturnFizz() {

            var result = FizzBuzz.GetOutput(3);

            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_WhenNumberDividedByFive_ReturnBuzz() {

            var result = FizzBuzz.GetOutput(5);

            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_WhenNumberDidNotDivideByThreeOrFive_ReturnNumberAsString() {

            var result = FizzBuzz.GetOutput(2);

            Assert.That(result, Is.EqualTo("2"));
        }
    }
}
