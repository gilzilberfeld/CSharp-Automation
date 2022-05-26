using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestAutomationCourse.Exercises.e09.Web
{
    [TestFixture]
    internal class BasicTests
    {
        IWebDriver driver;

        [SetUp]
        public void start_browser()
        {
            driver = new ChromeDriver();
        }



        [TearDown]
        public void close_browser()
        {
            driver.Close();
        }


    }
}
