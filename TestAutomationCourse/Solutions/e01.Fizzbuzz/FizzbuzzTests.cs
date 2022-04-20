using NUnit.Framework;

namespace TestAutomationCourse.Solutions.e01.Fizzbuzz
{
    [TestFixture]
    internal class FizzbuzzTests
    {
        [Test]
        public void CalculateFizzBuzz()
        {
            FizzbuzzCalculator fb = new FizzbuzzCalculator();
            Assert.AreEqual("1", fb.Calculate(1));
            Assert.AreEqual("fizz", fb.Calculate(6));
            Assert.AreEqual("buzz", fb.Calculate(10));
            Assert.AreEqual("fizzbuzz", fb.Calculate(30));

        }
    }
}
