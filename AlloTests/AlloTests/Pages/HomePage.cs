using OpenQA.Selenium;
using System;

namespace AlloTests.Pages
{
    public class HomePage : BasePage
    {
        private static readonly TimeSpan timeSpan = TimeSpan.FromSeconds(30);
        private const string language = "//span[contains(text(),'{0}')]";
        private const string locationButton = "//button[@class='mh-button']";
        private const string cityLink = "//div[@class='geo__cities']//a[contains(text(),'{0}')]";
        private const string locationSection = "//section[@class='geo']";
        private const string locationLabel = "//span[@class='mh-loc__label']";
        private const string selectedCity = "//*[@class='geo__selected']//strong";
        private const string search = "//input[@id='search-form__input']";
        private const string searchPopupModelsItems= "//a[@class='search-models__links']";
        private const string searchSubmitButton = "//button[@class='search-form__submit-button']";
        public HomePage(IWebDriver driver) : base(driver) { }

        public void SwitchLanguage(string lang)
        {
            WaitClickability(timeSpan, By.XPath(string.Format(language, lang)));
            driver.FindElement(By.XPath(string.Format(language, lang))).Click();
        }
        public void ClickCityButton()
        {
            WaitClickability(timeSpan, By.XPath(locationButton));
            driver.FindElement(By.XPath(locationButton)).Click();
        }
        public void ClickCityLink(string city)
        {
            WaitVisibility(timeSpan, By.XPath(locationSection));
            driver.FindElement(By.XPath(string.Format(cityLink, city))).Click();
        }
        public string GetLocationLabel()
        {
            WaitClickability(timeSpan, By.XPath(locationButton));
            return driver.FindElement(By.XPath(locationLabel)).Text;
        }
        public string GetSelectedCity()
        {
            WaitVisibility(timeSpan, By.XPath(locationSection));
            return driver.FindElement(By.XPath(selectedCity)).Text;
        }
        public void EnterKeywordToSearch(string keyword)
        {
            WaitVisibility(timeSpan, By.XPath(search));
            driver.FindElement(By.XPath(search)).Click();
            driver.FindElement(By.XPath(search)).SendKeys(keyword);
        }
        public void SearchByKeyword(string keyword)
        {
            WaitVisibility(timeSpan, By.XPath(search));
            driver.FindElement(By.XPath(search)).Click();
            driver.FindElement(By.XPath(search)).SendKeys(keyword);
            driver.FindElement(By.XPath(searchSubmitButton)).Submit();
        }
        public void ClickItemFromSearchPopup(int index)
        {
            WaitAllElementsVisibility(timeSpan, By.XPath(searchPopupModelsItems));
            var searchPopupItemsList = driver.FindElements(By.XPath(searchPopupModelsItems));
            searchPopupItemsList[index - 1].Click();
        }
    }
}
