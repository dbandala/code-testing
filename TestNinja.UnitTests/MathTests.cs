using NUnit.Framework;
using System.Linq;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class MathTests
    {
        private Math _math = new Math();
        
        // Setup
        [SetUp]
        public void Setup()
        {
            _math = new Math();
        }

        // TearDown
        [TearDown]
        public void Teardown()
        {
            _math = null;
        }

        [Test]
        [Ignore("Because I wanted to!")]
        public void Add_WhenCalled_ReturnSumOfArguments()
        {
            var result = _math.Add(1, 2);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Max_WhenCalled_ReturnFirstArgument()
        {
            var result = _math.Max(3, 1);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Max_WhenCalled_ReturnSecondArgument()
        {
            var result = _math.Max(1, 3);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Max_WhenCalled_ReturnSameArgument()
        {
            var result = _math.Max(3, 3);

            Assert.AreEqual(3, result);
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(3, 1, 3)]
        [TestCase(1, 3, 3)]
        [TestCase(3, 3, 3)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int exepectedResult)
        {
            var result = _math.Max(a, b);

            Assert.AreEqual((double)exepectedResult, result);
        }



        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            // test arrays
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count(), Is.EqualTo(3));

            // more general
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }
    }
}
