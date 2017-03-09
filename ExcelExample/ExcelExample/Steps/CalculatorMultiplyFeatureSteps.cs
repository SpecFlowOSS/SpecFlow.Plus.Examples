using System;
using TechTalk.SpecFlow;
using TestCalculator;

namespace ExcelExample.Steps
{
    [Binding]
    public class CalculatorMultiplyFeatureSteps
    {
        private readonly Calculator _calculator;

        public CalculatorMultiplyFeatureSteps(Calculator calculator)
        {
            _calculator = calculator;
        }

        [When(@"I press multiply")]
        public void WhenIPressMultiply()
        {
            _calculator.Multiply();
        }
    }
}
