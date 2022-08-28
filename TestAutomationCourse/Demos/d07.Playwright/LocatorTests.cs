using NUnit.Framework;
using Microsoft.Playwright.NUnit;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Playwright;
using System.Text.Json;

namespace TestAutomationCourse.Demos.d07.Playwright
{
    [TestFixture]
    internal class LocatorTests : PageTest
    {
        [Test]
        public async Task absolute_xpath()
        {
            await Page.GotoAsync("http://www.google.com");
            var search_input = Page.Locator(@"xpath=/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input");
            await search_input.FillAsync("automation");
            await search_input.PressAsync("Enter");
            await Expect(Page).ToHaveTitleAsync(new Regex("automation"));

        }


        [Test]
        public async Task contains_partial_text()
        {
            await Page.GotoAsync("http://www.duckduckgo.com");
            var simplified_text = Page.Locator(@"span:has-text('simp')");
            await Expect(simplified_text.Last).ToHaveTextAsync("Privacy, simplified.");

        }

        [Test]
        public async Task count_items_in_list()
        {
            await Page.GotoAsync("http://www.duckduckgo.com/?q=testing");

            // select by class
            var items_with_class = Page.Locator("[class=zcm__item]");
            Assert.That(await items_with_class.CountAsync(), Is.EqualTo(6));

            // # -> Id, > is selector inside selector
            var real_menu_items = Page.Locator("#duckbar_static > li");
            Assert.That(await real_menu_items.CountAsync(), Is.EqualTo(5));
        }

        [Test]
        [Ignore("Depends on loaded home page")]
        public async Task combined_id_inside_class()
        {
            await Page.GotoAsync("http://www.duckduckgo.com");
            var search_input = Page.Locator("searchbox_searchbox__eaWKL > #searchbox_input");
            await search_input.FillAsync("automation");
            await search_input.PressAsync("Enter");
            await Expect(Page).ToHaveTitleAsync(new Regex("automation"));
        }

        [Test]
        public async Task click_an_image()
        {
            await Page.GotoAsync("http://imgflip.com");
            await Page.Locator("#logo").ClickAsync();
            await Expect(Page).ToHaveTitleAsync(new Regex("Imgflip"));

        }

        [Test]
        public async Task find_active_element()
        {
            await Page.GotoAsync("http://www.google.com");
            var name = Page.Locator("[name='q']");
            await name.FillAsync("automation");
            JsonElement? active_element_name = await Page.EvaluateAsync("document.activeElement.name");
            Assert.That(active_element_name.ToString(), Is.EqualTo("q"));
        }

    }
}
