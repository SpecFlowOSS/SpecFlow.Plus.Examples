# Custom Deployment Steps Example

This Example demonstrates the usage of Custom Deployment Steps for setting up the testing environment.
The testing part is based on the [Windows App Driver Example](https://github.com/techtalk/SpecFlow.Plus.Examples/tree/master/WindowsAppDriver)
and utilizes Custom Deployment Steps to start/stop the Windows App Driver.

## Setup

In order for this project to work [WinAppDriver](https://github.com/Microsoft/WinAppDriver/releases) must be installed on the system and
the path to WinAppDriver.exe must bepassed as an argument to the Custom Deployment step in Default.srprofile.

## Related Documentation

Documentation for (Custom) Deployment Steps can be found [here](http://specflow.org/plus/documentation/SpecFlowPlus-Runner-Profiles/#DeploymentTransformation)