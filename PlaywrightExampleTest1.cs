
namespace PlaywrightTest_.Net_
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {

        /// <summary>
        /// Playwright can run tests on Chromium, WebKit and Firefox browsers 
        /// Run a test on the default Chromium browser binary (headless)
        /// By default Playwright Launches the browser in Headless mode, 
        /// to launch the browser in headed mode we should pass the argument as 
        /// headless=False in the Launch Method
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task PlaywrightExampleTest1()
        {
            //Since we are using the default Chrome browser = headless mode
            //the default settings are used, no initial setup required
            await Page.GotoAsync("https://playwright.dev");

            // Expect a title "to contain" a substring.
            await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

            // create a locator
            var getStarted = Page.Locator("text=Get Started");

            // Expect an attribute "to be strictly equal" to the value.
            await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

            // Click the get started link.
            await getStarted.ClickAsync();

            // Expects the URL to contain intro.
            await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
        }
    }
}
