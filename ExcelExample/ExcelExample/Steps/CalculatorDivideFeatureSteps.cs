using System;
using TechTalk.SpecFlow;
using TestCalculator;

namespace ExcelExample
{
    [Binding]
    public class CalculatorDivideFeatureSteps
    {
        private readonly Calculator _calculator;

        public CalculatorDivideFeatureSteps(Calculator calculator)
        {
            _calculator = calculator;
        }

        [When(@"I press divide")]
        public void WhenIPressDivide()
        {
            _calculator.Divide();
        }
    }
}
