using NUnit.Framework;
using Microsoft.Playwright.NUnit;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TestAutomationCourse.Demos.d07.Playwright
{
    [TestFixture]
    internal class BasicWebTests : PageTest
    {
        
        [Test]
        public async Task navigate_and_check_title()
        {
            await Page.GotoAsync("http://www.google.com");
            await Expect(Page).ToHaveTitleAsync("Google");
        }

        [Test]
        public async Task navigate_back_and_forward()
        {
            await Page.GotoAsync("http://www.google.com");
            await Page.GotoAsync("http://www.amazon.com");
            await Page.GoBackAsync();
            await Expect(Page).ToHaveTitleAsync("Google");
            await Page.GoForwardAsync();
            await Expect(Page).ToHaveTitleAsync(new Regex("Amazon"));

        }

        [Test]
        public async Task click_a_link()
        {
            await Page.GotoAsync("http://www.google.com");
            await Page.Locator("text=Gmail").ClickAsync();
            await Expect(Page).ToHaveTitleAsync(new Regex("Gmail"));
        }

        [Test]
        public async Task enter_text_submit()
        {
            await Page.GotoAsync("http://www.google.com");
            var name = Page.Locator("[name='q']");
            await name.FillAsync("automation");
            await name.PressAsync("Enter");
            await Expect(Page).ToHaveTitleAsync(new Regex("automation"));
        }

    }
}
