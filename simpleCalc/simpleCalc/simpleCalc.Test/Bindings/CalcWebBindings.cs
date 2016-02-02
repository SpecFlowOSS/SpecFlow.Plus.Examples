using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using simpleCalc.Test.Drivers;
using simpleCalc.Test.Pages;
using TechTalk.SpecFlow;

namespace simpleCalc.Test.Bindings
{
    [Binding, Scope(Tag = "Web")]
    class CalcViewWebBinding
    {
        private readonly CalcPage _calcPage;

        public CalcViewWebBinding(CalcPage calcPage)
        {
            _calcPage = calcPage;
        }

        [BeforeScenario("Web")]
        public void BeforeScenario()
        {
            _calcPage.GoTo();
        }

        [Given(@"the first operand is '(.*)'")]
        public void GivenTheFirstOperandIs(string value)
        {
            _calcPage.Operand1.SendKeys(value);
        }

        [Given(@"the function is '(.*)'")]
        public void GivenTheFunctionIs(string functionName)
        {
            switch (functionName.ToUpper())
            {
                case "PLUS":
                    _calcPage.PlusElement.Click();
                    break;
                case "MINUS":
                    _calcPage.MinusElement.Click();
                    break;
                case "MULTIPLY":
                    _calcPage.MultiplyElement.Click();
                    break;
                case "DIVIDE":
                    _calcPage.DivideElement.Click();
                    break;
            }
        }

        [Given(@"the second operand is '(.*)'")]
        public void GivenTheSecondOperandIs(string value)
        {
            _calcPage.Operand2.SendKeys(value);
        }

        [When(@"the calcuation is executed")]
        public void WhenTheCalcuationIsExecuted()
        {
            _calcPage.calcButton.Submit();
        }

        [Then(@"the result should be '(.*)'")]
        public void ThenTheResultShouldBe(string value)
        {
            _calcPage.result.Text.Should().Be(value);
        }

    }
}
