using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

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
            var driverOptions = GetDriverOptionsForBrowser(browserId);

            return new RemoteWebDriver(new Uri(_configurationDriver.SeleniumHub), driverOptions);
        }

        public DriverOptions GetDriverOptionsForBrowser(string browserId)
        {
            return browserId.ToUpper() switch
                {
                    "IE" => new InternetExplorerOptions(),
                    "CHROME"=> new ChromeOptions(),
                    "FIREFOX" => new FirefoxOptions(),
                    _ => throw new NotSupportedException($"{browserId} is not a supported browser")
                };
        }
    }
}
