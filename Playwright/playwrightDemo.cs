using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingToTheIntroPage()
    {
        await Page.GotoAsync("https://playwright.dev");

        //expect a title "to contain" a substring
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

        //create a locator
        var getStarted = Page.Locator("text=Get Started");

        //expect an attribute 'to be strictly expal' to the value.
        await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

        //click the get started link
        await getStarted.ClickAsync();

        //expect the URL to contain intro
        await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
    }
}
