using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SpecFlowProject.Pages
{
    class BasePage
    {
        protected readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly TimeSpan time = TimeSpan.FromSeconds(30);

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, time);
        }

        public void WaitPageToLoad()
        {
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
        public void WaitClickability(IWebElement webElement)
        {
            wait.Until(driver => (webElement != null && webElement.Displayed && webElement.Enabled) ? webElement : null);                           
        }
        public void WaitVisibility(IWebElement webElement)
        {
            wait.Until(driver => (webElement != null && webElement.Displayed) ? webElement : null);
        }
        public void WaitAlertIsPresent()
        {
            wait.Until(ExpectedConditions.AlertIsPresent());
        }
        public void WaitUrlContains(string text)
        {
            wait.Until(ExpectedConditions.UrlContains($"{text}"));
        }
    }
}
