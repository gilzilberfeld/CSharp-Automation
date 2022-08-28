using NUnit.Framework;
using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using System.Threading.Tasks;
using System.Text.Json;

namespace TestAutomationCourse.Demos.d07.Playwright
{
    [TestFixture]
    internal class SelectAndDropDownTests : PageTest
    {
        [Test]
        public async Task access_the_drop_down()
        {
            await Page.GotoAsync("https://demo.guru99.com/test/newtours/register.php");
            var country_drop_down = Page.Locator("[name=country]");
            var country_options = country_drop_down.Locator("option");
            Assert.That(await country_drop_down.GetAttributeAsync("multiple"), Is.Null);
            Assert.That(await country_options.CountAsync(), Is.EqualTo(264));
        }

        [Test]
        public async Task select_from_the_drop_down_by_text()
        {
            await Page.GotoAsync("https://demo.guru99.com/test/newtours/register.php");
            var country_drop_down = Page.Locator("[name=country]");
            await country_drop_down.SelectOptionAsync("ISRAEL");
            Assert.That(await country_drop_down.IsEnabledAsync(), Is.True);
            JsonElement? selected_value = await country_drop_down.EvaluateAsync("dropdown => dropdown.value");
            Assert.That(selected_value.ToString(), Is.EqualTo("ISRAEL"));
        }

        [Test]
        public async Task select_from_the_drop_down_by_index()
        {
            await Page.GotoAsync("https://demo.guru99.com/test/newtours/register.php");
            var country_drop_down = Page.Locator("[name=country]");
            await country_drop_down.SelectOptionAsync(new[] { new SelectOptionValue() { Index = 112 } });
            JsonElement? selected_value = await country_drop_down.EvaluateAsync("dropdown => dropdown.value");
            Assert.That(selected_value.ToString(), Is.EqualTo("ISRAEL"));
        }

    }
}
