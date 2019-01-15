Feature: Using VSCode and SpecFlow

    Background:
        Given I use VS Code

    Scenario: I want to write scenarios in VSCode without extensions

        Given I have no extensions installed
        When I write scenarios
        Then it is really boring


    Scenario: I want to write scenarios in VSCode with extensions

        Given I have following extensions installed:
            | Extension                       |
            | Cucumber (Gherkin) Full Support |

        When I write scenarios

        Then I have following functionality
            | Functionality          |
            | Syntax Highlighting    |
            | limited IntelliSense   |
            | formatting of document |
