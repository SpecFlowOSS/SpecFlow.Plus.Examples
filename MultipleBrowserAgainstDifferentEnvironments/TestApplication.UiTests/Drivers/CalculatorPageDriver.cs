using System.Collections.Generic;
using FluentAssertions;
using OpenQA.Selenium;

namespace TestApplication.UiTests.Drivers
{
    public class CalculatorPageDriver
    {
        private readonly WebDriver _webDriver;
        private readonly ConfigurationDriver _configurationDriver;

        private readonly IReadOnlyDictionary<int, string> _inputNumberToFieldNameMap = new Dictionary<int, string>
        {
            [0] = "summandOne",
            [1] = "summandTwo"
        };

        private int _currentInputNumber;

        public CalculatorPageDriver(WebDriver webDriver, ConfigurationDriver configurationDriver)
        {
            _webDriver = webDriver;
            _configurationDriver = configurationDriver;
        }

        public void GoToCalculatorPage()
        {
            string baseUrl = _configurationDriver.SeleniumBaseUrl;
            _webDriver.Current.Manage().Window.Maximize();
            _webDriver.Current.Navigate().GoToUrl($"{baseUrl}/");
        }

        public void EnterNumber(int number)
        {
            string id = GetMappingForInputNumber(_currentInputNumber);
            _webDriver.Wait.Until(d => d.FindElement(By.Id(id))).SendKeys(number.ToString());
            _currentInputNumber++;
        }

        public void PressAdd()
        {
            _currentInputNumber = 0;
            var addButton = _webDriver.Wait.Until(d => d.FindElement(By.Id("AddButton")));
            addButton.Submit();
        }

        public void ValidateResultShouldBe(int expectedResult)
        {
            var result = _webDriver.Wait.Until(d => d.FindElement(By.Id("result")));

            result.Text.Should().Be(expectedResult.ToString());
        }

        public string GetMappingForInputNumber(int number)
        {
            return _inputNumberToFieldNameMap[number];
        }
    }
}
