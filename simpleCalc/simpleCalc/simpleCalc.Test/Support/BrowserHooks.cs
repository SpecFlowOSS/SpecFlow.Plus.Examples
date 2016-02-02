using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace simpleCalc.Test.Support
{
    [Binding]
    public class BrowserHooks
    {
        private readonly BrowserContext browserContext;

        public BrowserHooks(BrowserContext browserContext)
        {
            this.browserContext = browserContext;
        }

        [AfterTestRun]
        public static void CloseBrowser()
        {
            BrowserContext.Quit();
        }

        [AfterScenario("web")]
        public void HandleWebErrors()
        {
            if (ScenarioContext.Current.TestError != null && browserContext.IsInitialized)
            {
                CloseBrowser(); // restart browser in case of an error
            }
        }
    }
}
