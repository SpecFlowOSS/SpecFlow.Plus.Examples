using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestApplication.UiTests.Drivers;

namespace TestApplication.UiTests.Support
{
    [Binding]
    public class WebserverHooks
    {
        private readonly WebServerDriver _webServerDriver;

        public WebserverHooks(WebServerDriver webServerDriver)
        {
            _webServerDriver = webServerDriver;
        }


        [BeforeScenario(Order = 1000)]
        public void StartWebserver()
        {
            _webServerDriver.Start();
        }

        [AfterScenario()]
        public async Task StopWebserver()
        {
            await _webServerDriver.Stop();
        }
    }
}