using NUnit.Framework;

namespace TestAutomationCourse.Solutions.e03.Refactoring
{
    [TestFixture]
    internal class CalculatorDisplayTests
    {
        private CalculatorDisplay calc;

        [SetUp]
        public void Setup()
        {
            calc = new CalculatorDisplay();
        }

        [Test]
        public void On_start_show_0()
        {
            Assert.AreEqual("0", calc.GetDisplay());
        }

        [Test]
        public void Only_numbers()
        {
            PressAll("13");
            Assert.AreEqual("13", calc.GetDisplay());
        }

        [Test]
        public void Number_and_operation_show_only_number()
        {
            PressAll("1+");
            Assert.AreEqual("1", calc.GetDisplay());
        }

        private void PressAll(string keys)
        {
            foreach (char c in keys)
            {
                calc.Press(c.ToString());
            }
        }

    }
}
