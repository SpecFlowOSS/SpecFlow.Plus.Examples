using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCode.Tests.Drivers;
using TechTalk.SpecFlow;

namespace DatabaseCode.Tests.StepDefinitions
{
    [Binding]
    public class GivenDatabaseSteps
    {
        private readonly DatabaseInitializationDriver _databaseInitializationDriver;

        public GivenDatabaseSteps(DatabaseInitializationDriver databaseInitializationDriver)
        {
            _databaseInitializationDriver = databaseInitializationDriver;
        }

        [Given(@"I have an empty database")]
        public void GivenIHaveAnEmptyDatabase()
        {
            _databaseInitializationDriver.CreateEmptyDatabase();
        }

        [Given(@"I have a database containing the following persons:")]
        public void GivenIHaveADatabaseContainingTheFollowingPersons(Table personsTable)
        {
            _databaseInitializationDriver.CreateDatabaseFromTable(personsTable);
        }
    }
}
