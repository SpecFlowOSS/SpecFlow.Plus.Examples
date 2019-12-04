using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace WindowsAppDriver.Driver
{
    public class WinAppDriver : IDisposable
    {
        private readonly ConfigurationDriver _configurationDriver;
        private readonly Lazy<WindowsDriver<WindowsElement>> _windowsDriverLazy;
        private bool _isDisposed;

        public WinAppDriver(ConfigurationDriver configurationDriver)
        {
            _configurationDriver = configurationDriver;
            _windowsDriverLazy = new Lazy<WindowsDriver<WindowsElement>>(GetCurrentDriver);
        }

        public WindowsDriver<WindowsElement> Current => _windowsDriverLazy.Value;

        private WindowsDriver<WindowsElement> GetCurrentDriver()
        {
            var appiumOptions = new AppiumOptions();

            appiumOptions.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");

            string appSetting =  _configurationDriver.Configuration["winAppUri"];
            var remoteAddress = new Uri(appSetting);

            var driver = new WindowsDriver<WindowsElement>(remoteAddress, appiumOptions);
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);

            return driver;
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (!_windowsDriverLazy.IsValueCreated)
            {
                return;
            }

            _windowsDriverLazy.Value.Quit();
            _windowsDriverLazy.Value.Dispose();
            _isDisposed = true;
        }
    }
}
