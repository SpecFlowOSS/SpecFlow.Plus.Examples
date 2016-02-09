using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace contactlist.Test.Bindings
{
    [Binding]
    class AddContactSteps
    {
        [Given(@"I enter following data in the ""(.*)"" dialog:")]
        public void GivenIEnterFollowingDataInTheDialog(string p0, Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I save the contact")]
        public void WhenISaveTheContact()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the following contacts are stored:")]
        public void ThenTheFollowingContactsAreStored(Table table)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
