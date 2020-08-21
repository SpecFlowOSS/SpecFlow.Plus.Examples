using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TestApplication.UiTests.Drivers;

namespace TestApplication.UiTests.Steps
{
    [Binding]
    public class Steps
    {
        private readonly BrowserDriver _browserDriver;

        public Steps(BrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
        }

        [When(@"I am on the search page")]
        public void WhenIAmOnTheSearchPage()
        {
            
        }

        [Then(@"the title is ""(.*)""")]
        public void ThenTheTitleIs(string expectedTitle)
        {
            _browserDriver.ValidateTitleShouldBe(expectedTitle);
        }

    }
}
