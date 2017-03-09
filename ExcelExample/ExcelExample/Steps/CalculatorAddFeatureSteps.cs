using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TestCalculator;

namespace ExcelExample.Steps
{
    [Binding]
    public class CalculatorAddFeatureSteps
    {
        private readonly Calculator _calculator;

        public CalculatorAddFeatureSteps(Calculator calculator)
        {
            _calculator = calculator;
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _calculator.Add();
        }
    }
}