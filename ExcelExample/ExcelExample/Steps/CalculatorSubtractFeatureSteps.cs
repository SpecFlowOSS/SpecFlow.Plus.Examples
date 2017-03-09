using System;
using TechTalk.SpecFlow;
using TestCalculator;

namespace ExcelExample.Steps
{
    [Binding]
    public class CalculatorSubtractFeatureSteps
    {
        private readonly Calculator _calculator;

        public CalculatorSubtractFeatureSteps(Calculator calculator)
        {
            _calculator = calculator;
        }

        [When(@"I press substract")]
        public void WhenIPressSubstract()
        {
            _calculator.Subtract();
        }
    }
}
