using Microsoft.Playwright;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTest_.Net_.ClassFiles
{
    public class WebLaunchClass : PageTest
    {

        //Define Global Class vars
        IBrowser? browser = null;
        IBrowserType? browserType = null;
        IPage? page = null;
        public async Task LaunchDefaultBrowser(string browserString)
        {

            //Create a local variable to hold the brower type
            //Note to create a var you must declare the implicited type
            //not the generic 'var' type
            Boolean isError = false;
            String errorString = String.Empty;

            try
            {
                //What browser to display
                var browserCase = browserString.ToUpper();
                switch (browserCase)
                {
                    case "CHROME":
                        //************ comment out ***********************
                        //Keeps displaying error
                        //Object reference not set to an instance of an object
                        //
                        //Initial Setup Chrome browser instance, attach a page
                        //var playwright = await Playwright.CreateAsync();
                        //browserType = Playwright.Chromium;
                        //browser = await browserType.LaunchAsync(new() { Headless = false });
                        await LaunchDefaultChrome();
                        break;

                    case "FIREFOX":
                        //Initial Setup Fiefox browser instance, attach a page
                        //var playwright = await Playwright.CreateAsync();
                        //browserType = Playwright.Firefox;
                        //browser = await browserType.LaunchAsync(new() { Headless = false });
                        //************ comment out ***********************
                        //Keeps displaying error
                        //Object reference not set to an instance of an object
                        
                        await LaunchDefaultFirefox();

                        break;

                    default:
                        browser = null;
                        isError = true;
                        errorString = "Browser Type(" + browserString + ") Not Implemented";
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            //Check for errors
            if (isError)
            {
                throw new Exception(errorString);
            }

            //From this point on we are using the page object
            //business as usual  
            if (browser != null)
            {
                page = await browser.NewPageAsync();
            }


        }

        public async Task LaunchDefaultFirefox()
        {
            //Initial Setup Firefox browser instance, attach a page
            //var playwright = await Playwright.CreateAsync();
            var type = Playwright.Firefox;
            var browser = await type.LaunchAsync(new() { Headless = false });
            var page = await browser.NewPageAsync();

        }

        public async Task LaunchDefaultChrome()
        {
            //Initial Setup Firefox browser instance, attach a page
            //var playwright = await Playwright.CreateAsync();
            var type = Playwright.Chromium;
            var browser = await type.LaunchAsync(new() { Headless = false });
            var page = await browser.NewPageAsync();

        }

    }
}


