namespace TestAutomationCourse.Exercises.e01.Fizzbuzz
{
    public class FizzbuzzCalculator
    {
        public string Calculate(int i)
        {
            if (i % 15 == 0)
                return "fizzbuzz";
            if (i % 3 == 0)
                return "fizz";
            if (i % 5 == 0)
                return "buzz";
            return i.ToString();
        }
    }
}
