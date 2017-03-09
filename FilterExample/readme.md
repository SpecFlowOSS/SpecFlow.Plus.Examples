# Filter Example
This example shows the usage of filters in combination with Profiles to run only selected tests.

If the tests are started with Simple.runsettings the Simple.srprofile is used with has a filter defined
that only runs tests tagged with @Simple. The Complex.runsettings file on the other hand only
runs tests tagged with @Complex. For a complete list of available filter options see http://specflow.org/plus/documentation/SpecFlowPlus-Runner-Profiles/#Filter