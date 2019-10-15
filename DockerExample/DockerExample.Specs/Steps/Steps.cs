using TechTalk.SpecFlow;
using DockerExample.Specs.Drivers;

namespace DockerExample.Specs.StepDefinitions
{
    [Binding]
    public class Steps
    {
        private readonly Driver _driver;

        public Steps(Driver driver)
        {
            _driver = driver;
        }

        [Given(@"Put your Background here")]
        public void GivenPutYourBackgroundHere()
        {
            _driver.CreateBackground();
        }

        [When(@"Put your Action here")]
        public void WhenPutYourActionHere()
        {
            _driver.ExecuteAction();
        }

        [Then(@"Put your Condition here")]
        public void ThenPutYourConditionHere()
        {
            _driver.CheckCondition();
        }
    }
}
