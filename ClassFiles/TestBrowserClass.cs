using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTest_.Net_.ClassFiles
{
    public class TestBrowserClass : PageTest
    {
        public async void TestPlaywrightDev(string browserString)
        {

            var webLaunchClass = new WebLaunchClass();
            await webLaunchClass.LaunchDefaultBrowser(browserString);


            //From this point on we are using the page object
            //business as usual  
            //IPage page = await browser.NewPageAsync();

            //***********************************************************
            //Calling the WebLaunchClass populates the following class vars
            //browser, browserType, page
            //populate local vars with the Class vars
            var browser = webLaunchClass.Browser;
            var browserType = webLaunchClass.BrowserType;
            var page = webLaunchClass.Page;

            //Now use can goto the web site
            await page.GotoAsync("https://playwright.dev");

            // Expect a title "to contain" a substring.
            //Copy Paste from the test example
            //await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

            //Need to create a locator to read the text
            //Locator based on 
            //< span class="highlight_gXVj">Playwright</span>
            //<h1 class="hero__title heroTitle_ohkl"><span class="highlight_gXVj">Playwright</span>
            //enables reliable end-to-end testing for modern web apps.</h1>

            //var element = page.Locator("highlight_gXVj").First;
            //var element = page.Locator("hero__title heroTitle_ohkl").First;

            //Solution 
            //Had to use XPath at the top class level
            //<h1 class="hero__title heroTitle_ohkl">
            //<span class="highlight_gXVj">Playwright</span>
            //enables reliable end-to-end testing for modern web apps.</h1>

            var element = page.Locator("//*[@id=\"__docusaurus_skipToContent_fallback\"]/header/div/h1").First;
            var pageText = await element.AllInnerTextsAsync();

            //await ConstantExpectedAttribute(page.Locator("//*[@id=\"__docusaurus_skipToContent_fallback\"]/header/div/h1").First);
            //await ConstantExpectedAttribute((SubstringConstraint)element).(Contains.Substring("Playwright enables reliable end-to-end testing for modern web"));
            //var locatorText = "//*[@id=\"__docusaurus_skipToContent_fallback\"]/header/div/h1";
            //await ConstantExpectedAttribute(page.Locator(locatorText)).toContainText('List Example');

            //****************************************************************************
            //Date 1/29/2024 finally found solution
            //You must inhert your user defined Class from :PageTest Class
            //Now use can use the Assert examples in the online docs
            await Expect(element).ToContainTextAsync("Playwright enables reliable end-to-end testing for modern web apps");


            await browser.CloseAsync();


        }



    }



}
