using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace TestApplication.UiTests.Drivers
{
    public class BrowserSeleniumDriverFactory
    {
        private readonly ConfigurationDriver _configurationDriver;

        public BrowserSeleniumDriverFactory(ConfigurationDriver configurationDriver)
        {
            _configurationDriver = configurationDriver;
        }

        public IWebDriver GetForBrowser(string browserId)
        {
            string lowerBrowserId = browserId.ToUpper();
            switch (lowerBrowserId)
            {
                case "IE": return GetInternetExplorerDriver();
                case "CHROME": return GetChromeDriver();
                case "FIREFOX": return GetFirefoxDriver();
                case string browser: throw new NotSupportedException($"{browser} is not a supported browser");
                default: throw new NotSupportedException("not supported browser: <null>");
            }
        }

        private IWebDriver GetFirefoxDriver()
        {
            return new FirefoxDriver
            {
                Url = _configurationDriver.SeleniumBaseUrl
            };
        }

        private IWebDriver GetChromeDriver()
        {
            return new ChromeDriver
            {
                Url = _configurationDriver.SeleniumBaseUrl
            };
        }

        private IWebDriver GetInternetExplorerDriver()
        {
            var internetExplorerOptions = new InternetExplorerOptions
            {
                IgnoreZoomLevel = true
            };
            return new InternetExplorerDriver(internetExplorerOptions)
            {
                Url = _configurationDriver.SeleniumBaseUrl
            };
        }
    }
}
