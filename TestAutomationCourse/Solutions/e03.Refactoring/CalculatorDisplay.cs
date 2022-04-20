using System;

namespace TestAutomationCourse.Solutions.e03.Refactoring
{
    internal class CalculatorDisplay
    {
        string result = "0";

        public string GetDisplay()
        {
            return result;
        }

        public void Press(string key)
        {
            if (ResultIs("0"))
            {
                result = key;
                return;
            }
            if (IsNotOperation(key))
                result += key;
        }

        private bool ResultIs(String aResult)
        {
            return result.Equals(aResult);
        }

        private bool IsNotOperation(String key)
        {
            return !key.Equals("+");
        }
    }
}