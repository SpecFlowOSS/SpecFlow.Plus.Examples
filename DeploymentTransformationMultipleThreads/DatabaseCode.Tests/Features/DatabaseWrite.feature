Feature: Database Write
    As a system
    I want to modify the data inside my database
    in order to work properly

Scenario Outline: Creating a person in an empty database
    Given I have an empty database
    And I have an established connection to that database
    When I insert a person called "<FirstName> <LastName>" into the database
    And I save and commit the changes to the database
    Then the database should contain a person called "<FirstName> <LastName>".

    Examples:
    | FirstName | LastName |
    | David     | Eiwen    |

Scenario Outline: Modifying a person's name in the database
    Given I have a database containing the following persons:
        | FirstName | LastName |
        | David     | Eiwen    |

    And I have an established connection to that database
    And I have the model object of the person "<OldFirstName> <OldLastName>"
    When I set the first name of the model object to "<NewFirstName>"
    And I set the last name of the model object to "<NewLastName>"
    And I save and commit the changes to the database
    Then the database should contain a person called "<FirstName> <LastName>".

Scenario Outline: Deleting a person in the database
    Given I have a database containing the following persons:
        | FirstName | LastName |
        | David     | Eiwen    |
    And I have an established connection to that database
    When I delete a person called "<FirstName> <LastName>"
    And I save and commit the changes to the database
    Then the database should not contain a person called "<FirstName> <LastName>".

Scenario: Clearing all persons from the database
    Given I have a database containing the following persons:
        | FirstName | LastName |
        | David     | Eiwen    |
    And I have an established connection to that database
    When I remove all persons
    And I save and commit the changes to the database
    Then the database should not contain any person.