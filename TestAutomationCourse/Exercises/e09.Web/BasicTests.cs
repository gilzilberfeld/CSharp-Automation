using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace TestAutomationCourse.Exercises.e09.Web
{
    [TestFixture]
    internal class BasicTests
    {
        // click the "about" link, which is not a link, on the google page

        // find the name of the google image
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
