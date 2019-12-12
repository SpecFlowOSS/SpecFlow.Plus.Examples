using System.Configuration;
using FluentAssertions;
using TechTalk.SpecFlow;
using TestApplication.UiTests.Drivers;

namespace TestApplication.UiTests.Steps
{
    [Binding]
    public class Browser
    {
        private readonly BrowserDriver _browserDriver;

        public Browser(BrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
        }

        [Then(@"browser title should be '(.*)'")]
        public void ThenBrowserTitleIs(string expectedTitle)
        {
            _browserDriver.ValidateTitleShouldBe(expectedTitle);
        }
    }
}
