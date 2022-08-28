using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

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

        
        [Test]
        public void contains_partial_text()
        {
            driver.Url = "http://www.duckduckgo.com";
            IWebElement simplified_text = driver.FindElement(By.XPath(
                ".//h1[contains(text(), 'simp')]"));
            Assert.That(simplified_text.Text, Is.EqualTo("Privacy, simplified."));
        }

        [Test]
        public void count_items_in_list()
        {
            driver.Url = "https://duckduckgo.com/?q=testing";
            ReadOnlyCollection<IWebElement> menu_items = driver.FindElements(By.ClassName(
                "zcm__item"));
            Assert.That(menu_items.Count, Is.EqualTo(6)); // not all in the same menu

            IWebElement main_menu = driver.FindElement(By.Id(
                "duckbar_static"));
            var main_menu_items = main_menu.FindElements(By.TagName("li"));
            Assert.That(main_menu_items.Count, Is.EqualTo(5));
             
        }

        [Test]
        public void class_and_relative_xpath()
        {
            driver.Url = "http://www.duckduckgo.com";
            IWebElement div_element = driver.FindElement(By.ClassName("searchbox_searchbox__eaWKL"));
            IWebElement search_input = div_element.FindElement(By.XPath(
                "input[@id='searchbox_input']"));
            search_input.SendKeys("automation");
            search_input.Submit();
            Assert.That(driver.Title, Does.Contain("automation"));
        }


        [Test]
        public void click_an_image()
        {
            driver.Url = "http://imgflip.com";
            IWebElement logo_image = driver.FindElement(By.Id("logo"));
            logo_image.Click();
            Assert.That(driver.Title, Does.Contain("Imgflip"));
        }

        
        [Test]
        public void find_active_element()
        {
           
            driver.Url = "http://www.duckduckgo.com";
            IWebElement search_input = driver.FindElement(By.CssSelector(
                "[name='q']"));
            search_input.SendKeys("automation");
            IWebElement search_input2 = driver.SwitchTo().ActiveElement();
            Assert.That(search_input2, Is.EqualTo(search_input));
        }
        [TearDown]
        public void close_browser()
        {
            driver.Quit();
        }

    }
}
