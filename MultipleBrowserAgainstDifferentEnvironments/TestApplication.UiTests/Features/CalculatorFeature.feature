Feature: CalculatorFeature
	 In order to avoid silly mistakes 
	As a math idiot
	I want to be told the sum of two numbers

@Browser_Chrome
@Browser_IE
@Browser_Firefox
@BasePage
Scenario: Basepage is Calculator
	When I navigate to the Calculator page
	Then browser title should be 'Calculator'

@Browser_IE 
@Browser_Chrome
Scenario Outline: Add Two Numbers
	Given I navigated to the Calculator page

	When I enter '<SummandOne>' into the calculator
	And I enter '<SummandTwo>' into the calculator
	And I press add

	Then the result should be '<Result>'

Scenarios: 
		| SummandOne | SummandTwo | Result |
		| 50         | 70         | 120    |
		| 1          | 10         | 11     |
