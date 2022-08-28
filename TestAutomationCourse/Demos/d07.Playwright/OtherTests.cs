using NUnit.Framework;
using Microsoft.Playwright.NUnit;
using System.Threading.Tasks;
using Microsoft.Playwright;
using System.Threading;

namespace TestAutomationCourse.Demos.d07.Playwright
{
    [TestFixture]
    internal class OtherTests : PageTest
    {

        [Test]
        public async Task text_box_is_enabled()
        {
            await Page.GotoAsync("https://demo.guru99.com/test/newtours/register.php");
            var name_text = Page.Locator("[name=firstName]");
            await Expect(name_text).ToBeVisibleAsync();
            await Expect(name_text).ToBeEnabledAsync();
        }

        [Test]
        public async Task drag_and_drop()
        {
            await Page.GotoAsync("http://demo.guru99.com/test/drag_drop.html");
            var from_selector = "#credit2 > a";
            var From = Page.Locator(from_selector);
            var value_dragged = await From.TextContentAsync();

            var to_selector = "#bank > li";
            var To = Page.Locator(to_selector);
            var to_text = await To.TextContentAsync();

            Assert.That(to_text, Does.Not.EqualTo(value_dragged));
            await Page.DragAndDropAsync(from_selector, to_selector);

            // Don't need to retake stale element - it's updated
            // Need Trim because dragging can be embedded inside existing white space
            Assert.That((await To.TextContentAsync()).Trim(), Is.EqualTo(value_dragged.Trim()));
        }

        [Test]
        public async Task execute_script_and_close_alert()
        {
            await Page.GotoAsync("http://demo.guru99.com/V4/");

            // Playwright usually closes dialogs / alerts automatically.
            // But if we want to capture something, use this.
            // Need to register the event before the alert
            Page.Dialog += async (_, dialog) =>
            {
                // Called on another thread!
                Assert.That(dialog.Message, Does.Contain("not valid"));
                // When registering the event, need to accept/dismiss manually
                await dialog.AcceptAsync();
            };

            await Page.Locator("[name=uid]").FillAsync("mngr34926");
            await Page.Locator("[name=password]").FillAsync("amUpenu");
            var login_button = Page.Locator("[name=btnLogin]");

            // This causes an alert to appear
            await login_button.EvaluateAsync("btn => btn.click()");

            // For demo only (waiting for the assert to occur), don't do it
            Thread.Sleep(5000);
        }

        [Test]
        public async Task screen_shot()
        {
            await Page.GotoAsync("https://demo.guru99.com/test/newtours/register.php");
            await Page.Locator("[name=firstName]").FillAsync("Gil");
            await Page.ScreenshotAsync(new PageScreenshotOptions()
            {
                Path = ".//Image.png",
                FullPage = true,
            });

        }

    }
}
