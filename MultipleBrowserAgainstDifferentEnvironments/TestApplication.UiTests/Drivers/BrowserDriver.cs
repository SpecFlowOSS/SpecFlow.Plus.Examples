using FluentAssertions;

namespace TestApplication.UiTests.Drivers
{
    public class BrowserDriver
    {
        private readonly WebDriver _webDriver;
        private readonly ConfigurationDriver _configurationDriver;

        public BrowserDriver(WebDriver webDriver, ConfigurationDriver configurationDriver)
        {
            _webDriver = webDriver;
            _configurationDriver = configurationDriver;
        }

        public void OpenBasePage()
        {
            _webDriver.Current.Url = _configurationDriver.SeleniumBaseUrl;
        }

        public void ValidateTitleShouldBe(string expectedTitle)
        {
            string result = _webDriver.Wait.Until(d => d.Title);
            result.Should().Be(expectedTitle);
        }
    }
}
