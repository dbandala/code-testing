using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class FizzBuzzTests
    {
        [Test]
        [TestCase(15, "FizzBuzz")]
        [TestCase(6, "Fizz")]
        [TestCase(10, "Buzz")]
        [TestCase(8, "8")]
        public void GetOutput_WhenCalled_ReturnValidResult(int number, string expected)
        {
            var result = FizzBuzz.GetOutput(number);
            // verify it is not null
            Assert.That(result, Is.Not.Null);
            // verify result
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
