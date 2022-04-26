using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestAutomationCourse.Demos.d06.Web.d1.Basic
{
    [TestFixture]
    internal class LocatorTests
    {
        IWebDriver driver;

        [SetUp]
        public void start_browser()
        {
            driver = new ChromeDriver();
        }


        [Test]
        public void absolute_xpath()
        {
            driver.Url = "http://www.google.com";
            IWebElement search_input = driver.FindElement(By.XPath(
                "/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input"));
            search_input.SendKeys("automation");
            search_input.Submit();
            Assert.That(driver.Title, Does.Contain("automation"));
        }

        // relative

        [Test]
        public void click_an_image()
        {
            driver.Url = "http://www.duckduckgo.com";
            IWebElement duck_image = driver.FindElement(By.Id("logo_homepage_link"));
            duck_image.Click();
            Assert.That(driver.Title, Does.Contain("DuckDuckGo"));
        }

        [TearDown]
        public void close_browser()
        {
            driver.Close();
        }

    }
}
