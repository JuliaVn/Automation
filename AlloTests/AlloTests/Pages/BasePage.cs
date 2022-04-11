using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;

namespace AlloTests.Pages
{
    public class BasePage
    {
        internal IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitPageToLoad(TimeSpan timeToWait)
        {
            new WebDriverWait(driver, timeToWait).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void ScrollBy()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,800)");
        }

        public void WaitVisibility(TimeSpan timeToWait, By locator)
        {
            new WebDriverWait(driver, timeToWait).Until(
                ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitClickability(TimeSpan timeToWait, By locator)
        {
            new WebDriverWait(driver, timeToWait).Until(
                ExpectedConditions.ElementToBeClickable(locator));
        }

        public void WaitAllElementsVisibility(TimeSpan timeToWait, By locator)
        {
            new WebDriverWait(driver, timeToWait).Until(
                ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        public void WaitInvisibility(TimeSpan timeToWait, By locator)
        {
            new WebDriverWait(driver, timeToWait).Until(
                ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public void WaitUntilUrlToBe(TimeSpan timeToWait, string url)
        {
            new WebDriverWait(driver, timeToWait).Until(
                ExpectedConditions.UrlToBe(url));
        }
    }
}
