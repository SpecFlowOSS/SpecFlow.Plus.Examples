Feature: Calc

#@Web
Scenario: Add two numbers - Web
	Given the first operand is '5.00'
	And the function is 'plus'
	And the second operand is '7.00'
	When the calcuation is executed
	Then the result should be '12.00'
#
#@ViewModel
#Scenario: Add two numbers - ViewModel
#	Given the first operand is '5.00'
#	And the function is 'plus'
#	And the second operand is '7.00'
#	When the calcuation is executed
#	Then the result should be '12.00'
