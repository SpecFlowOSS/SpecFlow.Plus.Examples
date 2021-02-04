# Selenium Web Test Example

This is a example how to use SpecFlow and SpecFlow+Runner to run Selenium Web Tests for different Browsers.  
The example is based on https://github.com/baseclass/Contrib.SpecFlow.Selenium.NUnit

This example also takes a screenshot after each step and embeds the screnshot in the final report. Refer to the documentation [here](http://www.specflow.org/plus/documentation/Tutorial:-Customising-Reports) for an explanation of how the screenshot's path is passed to the report.

There is an article covering this project [here](https://specflow.org/2019/targeting-multiple-browser-with-a-single-test-with-specflow-3/).

## Important parts

### Default.srprofile

#### Targets
3 Targets are defined here, one for each browser. The targets have a filter applied so that only those scenarios tagged for a particular browser are executed by the target (using "@Browser_IE", "@Browser_Chrome", "@Browser_Firefox").

#### DeploymentSteps
Deployment transformations steps are configured:
1. IISExpress: This starts an IIS Express instance, saving you from manually needing to check it is running
2. EnvironmentVariable (once per target): This sets the environment variable *Test_Browser* to the desired browser name


### WebDriver.cs
This driver provides you access to the appropriate Selenium WebDriver. It uses the aforementioned environment variable *Test_Browser* value for this, which is set in the target configuration.
To get access to the Selenium Web Driver, use the _Current_ property on it. Use [Context Injection](http://www.specflow.org/documentation/Context-Injection/) to get the instance.


### CalculatorFeature.feature
Here are the scenarios defined.  
To get a scenario executed for a browser, add a tag _Browser_\_**__{BrowserName}__** to the scenario/scenario outline/feature.  

**Example for a scenario for all 3 browsers:**
```
@Browser_Chrome
@Browser_IE
@Browser_Firefox
Scenario: Basepage is Calculator
	Given I navigated to /
	Then browser title is Calculator
```
