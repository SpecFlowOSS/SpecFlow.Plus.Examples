using System;
using TechTalk.SpecFlow;

namespace TestProject.Bindings
{
    [Binding]
    public class VSCodeBindings
    {
        [Given("I use VS Code")]
        public void IUseVSCode()
        {
        }  

        [Given("I have no extensions installed")]
        public void IHaveNoExtensionsInstalled()
        {
        }

        [Given("I have following extensions installed:")]
        public void IHaveFollowingExtensionsInstalled(Table table)
        {
        }

        [When("I write scenarios")]
        public void IWriteScenarios()
        {
        }

        [Then("it is really boring")]
        public void ItIsReallyBoring()
        {
            throw new Exception("You should install some extensions!");
        }


        [Then("I have following functionality")]
        public void IHaveFollowingFunctionality(Table table)
        {
        }
    }
}