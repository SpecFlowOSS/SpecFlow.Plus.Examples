using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace AccessTargetName.Steps
{
    [Binding]
    public class Binding
    {
        [Given(@"the target name is provided as environment variable")]
        public void GivenTheTargetNameIsProvidedAsEnvironmentVariable()
        {
            var targetName = Environment.GetEnvironmentVariable("RUNNER_TARGET");

            Console.WriteLine(targetName);
        }

    }
}
