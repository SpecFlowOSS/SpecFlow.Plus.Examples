using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestApplication.UiTests.Drivers
{
    public class WebDriver : IDisposable
    {
        private readonly BrowserSeleniumDriverFactory _browserSeleniumDriverFactory;
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private readonly Lazy<WebDriverWait> _waitLazy;
        private readonly TimeSpan _waitDuration = TimeSpan.FromSeconds(10);
        private bool _isDisposed;

        public WebDriver(BrowserSeleniumDriverFactory browserSeleniumDriverFactory)
        {
            _browserSeleniumDriverFactory = browserSeleniumDriverFactory;
            _currentWebDriverLazy = new Lazy<IWebDriver>(GetWebDriver);
            _waitLazy = new Lazy<WebDriverWait>(GetWebDriverWait);
        }

        public IWebDriver Current => _currentWebDriverLazy.Value;

        public WebDriverWait Wait => _waitLazy.Value;

        private WebDriverWait GetWebDriverWait()
        {
            return new WebDriverWait(Current, _waitDuration);
        }

        private IWebDriver GetWebDriver()
        {
            string testBrowserId = Environment.GetEnvironmentVariable("Test_Browser");
            return _browserSeleniumDriverFactory.GetForBrowser(testBrowserId);
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;
        }
    }
}
