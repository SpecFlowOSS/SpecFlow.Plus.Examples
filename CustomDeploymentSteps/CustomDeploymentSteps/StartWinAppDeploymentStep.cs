using System;
using System.Diagnostics;
using TechTalk.SpecRun.Framework;

namespace CustomDeploymentSteps
{
    public class StartWinAppDeploymentStep : IDeploymentTransformationStep
    {
        private Process _winApp;

        public void Apply(IDeploymentContext deploymentContext)
        {
            var pathToWinApp = deploymentContext.CustomData[this] as string;
            if (pathToWinApp != null)
            {
                _winApp = Process.Start(pathToWinApp);
            }
        }

        public void Restore(IDeploymentContext deploymentContext)
        {
            _winApp.Kill();
        }
    }
}
