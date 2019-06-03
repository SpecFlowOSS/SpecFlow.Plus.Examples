using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace TestApplication.UiTests.Drivers
{
    public class WebDriver
    {
        private IWebDriver _currentWebDriver;
        private WebDriverWait _wait;

        public string SeleniumBaseUrl => ConfigurationManager.AppSettings["seleniumBaseUrl"];

        public IWebDriver Current
        {
            get
            {
                if (_currentWebDriver == null)
                {
                    _currentWebDriver = GetWebDriver();
                }

                return _currentWebDriver;
            }
        }

        public WebDriverWait Wait
        {
            get
            {
                if (_wait == null)
                {
                    this._wait = new WebDriverWait(Current, TimeSpan.FromSeconds(10));
                }
                return _wait;
            }
        }

        private IWebDriver GetWebDriver()
        {
            switch (Environment.GetEnvironmentVariable("Test_Browser"))
            {
                case "IE": return new InternetExplorerDriver(new InternetExplorerOptions { IgnoreZoomLevel = true }) { Url = SeleniumBaseUrl };
                case "Chrome": return new ChromeDriver { Url = SeleniumBaseUrl };
                case "Firefox": return new FirefoxDriver { Url = SeleniumBaseUrl };
                case string browser: throw new NotSupportedException($"{browser} is not a supported browser");
                default: throw new NotSupportedException("not supported browser: <null>");
            }
        }

        public void Quit()
        {
            _currentWebDriver?.Quit();
        }
    }
}
