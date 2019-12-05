using System;
using System.IO;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestApplication.UiTests.Drivers;

namespace TestApplication.UiTests.Support
{
    [Binding]
    public class Screenshots
    {
        private readonly WebDriver _webDriver;

        public Screenshots(WebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [AfterStep]
        public void MakeScreenshotAfterStep()
        {
            if (_webDriver.Current is ITakesScreenshot takesScreenshot)
            {
                var screenshot = takesScreenshot.GetScreenshot();
                var tempFileName = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".jpg";
                screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Jpeg);

                Console.WriteLine($"SCREENSHOT[ file:///{tempFileName} ]SCREENSHOT");
            }
        }
    }
}
