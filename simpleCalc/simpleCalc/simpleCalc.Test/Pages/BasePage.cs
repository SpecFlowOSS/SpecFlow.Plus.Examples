using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using simpleCalc.Test.Support;

namespace simpleCalc.Test.Pages
{
    public abstract class BasePage
    {
        protected readonly BrowserContext browserContext;
        protected readonly string path;

        protected BasePage(BrowserContext browserContext, string path)
        {
            this.browserContext = browserContext;
            this.path = path;
            PageFactory.InitElements(browserContext.WebDriver, this);
        }

        public virtual void GoTo()
        {
            browserContext.NavigateTo(path);
        }

        public virtual void AssertOnPage()
        {
            browserContext.AssertOnPath(path);
        }
    }
}
