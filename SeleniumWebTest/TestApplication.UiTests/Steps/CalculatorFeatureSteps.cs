using TechTalk.SpecFlow;
using TestApplication.UiTests.Drivers;

namespace TestApplication.UiTests.Steps
{
    [Binding]
    public class CalculatorFeatureSteps
    {
        private readonly CalculatorPageDriver _calculatorPageDriver;

        public CalculatorFeatureSteps(CalculatorPageDriver calculatorPageDriver)
        {
            _calculatorPageDriver = calculatorPageDriver;
        }

        [Given(@"I navigated to the Calculator page")]
        [When(@"I navigate to the Calculator page")]
        public void GivenINavigatedToTheCalculatorPage()
        {
            _calculatorPageDriver.GoToCalculatorPage();
        }

        [When(@"I enter '(\d+)' into the calculator")]
        public void WhenIEnterNumberIntoTheCalculator(int number)
        {
            _calculatorPageDriver.EnterNumber(number);
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _calculatorPageDriver.PressAdd();
        }
        
        [Then(@"the result should be '(\d+)'")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            _calculatorPageDriver.ValidateResultShouldBe(expectedResult);
        }
    }
}
