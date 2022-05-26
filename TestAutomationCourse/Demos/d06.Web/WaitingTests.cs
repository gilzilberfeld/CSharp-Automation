using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace TestAutomationCourse.Demos.d06.Web
{
    [TestFixture]
    internal class WaitingTests
    {
        private ChromeDriver driver;

        [SetUp]
        public void start_browser()
        {
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");
            driver = new ChromeDriver(chromeOptions);
        }

        [Test]
        public void upload_files_and_wait_for_message()
        {
            driver.Url = "http://demo.guru99.com/test/upload/";
            IWebElement uploadElement = driver.FindElement(By.Id("uploadfile_0"));

            string path = Path.Combine(Environment.CurrentDirectory, @".//Demos//d06.Web//TextFile1.txt");
            uploadElement.SendKeys(path);
            driver.FindElement(By.Id("terms")).Click();
            driver.FindElement(By.Name("send")).Click();
            WaitForMessageToDisplay();

            IWebElement message = driver.FindElement(
                By.XPath(".//center[contains(text(), '1 file')]"));

            Assert.That(message.Text, Does.Contain("1 file")
                & Does.Contain("successfully"));
        }

        private void WaitForMessageToDisplay()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            Func<IWebDriver, bool> isMessageDisplayed =
            d =>
            {
                IWebElement e = d.FindElement(By.XPath(".//center[contains(text(), '1 file')]")); ;
                return e.Displayed && e.Enabled;
            };

            wait.Until(isMessageDisplayed);
        }

        [TearDown]
        public void close_browser()
        {
            driver.Close();
            if (File.Exists(@".//Image.png"))
            {
                File.Delete(@".//Image.png");
            }
        }

    }
}
