using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using PlaywrightTest_.Net_.ClassFiles;

namespace PlaywrightTest_.Net_.NUnit_Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        [SetUp]
        public void Initialize()
        {

        }

        [Test]
        public async Task LaunchLocalBrowser()
        {

            /**************** comment out ***********************************
                    
            //Launch Chrome local browser
            var chromePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";

            //Launch Edge local browser
            var edgePath = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Microsoft Edge";


          //Launch the browser
          var process = Process.Start(chromeBrowser, "https://playwright.dev/");

          //Wait for the UI page to be displayed
          process.WaitForInputIdle();

          // Close UI page by sending a close message to its main window.
          process.CloseMainWindow();
          // Free resources associated with process.
          process.Close();

          //Wait for the process to exit
          process.WaitForExit();

  **************** comment out ***********************************/

            //var playwright = await Playwright.CreateAsync();




        }

        [Test]

        ///*****************************************************
        /// Date 1/28/2024 I give up on this crap
        /// Playwright Home Page - https://playwright.dev/
        /// Launches and displays the default Chromium/Firefox browsers 
        /// not the Chrome/Firefox browser on the local machine
        /// To make GUI visible onscreen we must pass the parameter to launch() method 
        /// as headless=False.
        /// 
        public void TestPlaywrightDevChrome()
        {

            var browserClass = new TestBrowserClass();
            browserClass.TestPlaywrightDev("Chrome");


        }

        [Test]
        ///*****************************************************
        /// Date 1/28/2024 I give up on this crap
        /// Launches and displays the default Firefox browser 
        ///Playwright Home Page - https://playwright.dev/
        /// not the Firefox browser on the local machine
        /// To make GUI visible onscreen we must pass the parameter to launch() method 
        /// as headless=False.
        /// 
        public async Task LaunchDefaultFirefox()
        {
            //Initial Setup Firefox browser instance, attach a page
            //var playwright = await Playwright.CreateAsync();
            var firefox = Playwright.Firefox;
            var browser = await firefox.LaunchAsync(new() { Headless = false });
            var page = await browser.NewPageAsync();

            //From this point on we are using the page object
            //business as usual
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

            //Date 1/29/2024 finally found solution
            //You must inhert your user defined Class from :PageTest Class
            //Now use can use the Assert example in the online docs
            await Expect(element).ToContainTextAsync("Playwright enables reliable end-to-end testing for modern web apps");


            await browser.CloseAsync();

        }

        [Test]
        public async Task LaunchDefaultChrome()
        {
            //Initial Setup Firefox browser instance, attach a page
            //var playwright = await Playwright.CreateAsync();
            var chrome = Playwright.Chromium;
            var browser = await chrome.LaunchAsync(new() { Headless = false });
            var page = await browser.NewPageAsync();

            //From this point on we are using the page object
            //business as usual
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

            //Date 1/29/2024 finally found solution
            //You must inhert your user defined Class from :PageTest Class
            //Now use can use the Assert example in the online docs
            await Expect(element).ToContainTextAsync("Playwright enables reliable end-to-end testing for modern web apps");


            await browser.CloseAsync();

        }



        [TearDown] 
        public void Cleanup()
        { 
        }
    }
}
