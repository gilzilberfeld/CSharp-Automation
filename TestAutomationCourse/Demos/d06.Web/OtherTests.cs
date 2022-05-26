using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace TestAutomationCourse.Demos.d06.Web
{
    [TestFixture]
    internal class OtherTests
    {
        IWebDriver driver;

        [SetUp]
        public void start_browser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void text_box_is_enabled()
        {
            driver.Url = "https://demo.guru99.com/test/newtours/register.php";
            IWebElement name_text = driver.FindElement(By.Name("firstName"));
            Assert.That(name_text.Displayed, Is.True);
            Assert.That(name_text.Enabled, Is.True);

        }

        [Test]
        public void drag_and_drop()
        {
            driver.Url = "http://demo.guru99.com/test/drag_drop.html";
            IWebElement From = driver.FindElement(By.XPath("//*[@id='credit2']/a"));
            var value_dragged = From.Text;
            IWebElement To = driver.FindElement(By.XPath("//*[@id='bank']/li"));
            Assert.That(To.Text, Does.Not.EqualTo(value_dragged));
            Actions action = new Actions(driver);
            action.DragAndDrop(From, To).Build().Perform();
            // need to retake stale element
            To = driver.FindElement(By.XPath("//*[@id='bank']/li"));
            Assert.That(To.Text, Is.EqualTo(value_dragged));


        }

        [Test]
        public void execute_script_and_close_alert()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.Url = "http://demo.guru99.com/V4/";

            IWebElement button = driver.FindElement(By.Name("btnLogin"));

            //Login to Guru99 		
            driver.FindElement(By.Name("uid")).SendKeys("mngr34926");
            driver.FindElement(By.Name("password")).SendKeys("amUpenu");


            //Perform Click on LOGIN button. Shows an alert.		
            js.ExecuteScript("arguments[0].click();", button);

            //Close alert
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }


        [Test]
        public void screen_shot()
        {
            driver.Url = "https://demo.guru99.com/test/newtours/register.php";
            IWebElement name_text = driver.FindElement(By.Name("firstName"));
            name_text.SendKeys("Gil");
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(@".//Image.png", ScreenshotImageFormat.Png);
        }


        [TearDown]
        public void close_browser()
        {
            driver.Close();
        }
    }

}
