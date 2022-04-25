using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace AlloTests.Pages
{
    public class ResultPage : BasePage
    {
        private static readonly TimeSpan timeSpan = TimeSpan.FromSeconds(30);
        private const string productCartTitleList = "//a[@class='product-card__title']";
        private const string filterDiscountCheckbox= "//a[@id='filter_id-discount']";
        private const string priceRangeFrom = "//input[@id='pricerange-from']";
        private const string priceRangeTo = "//input[@id='pricerange-to']";
        private const string filterPopupButton = "//button[@class='filter-popup__button']";
        private const string productCardList = "//div[contains(@class,'product-card')]/parent::div[contains(@class,'products-layout__item')]";
        private const string loadingBlock = "//div[contains(@class,'loading-block-gif')]";
        private const string filterPriceButton = "//div[@class='filters__content']/div[@headerclass='filter__header'][1]";
        private const string itemsDiscountPriceTextList = "//div[@class='product-card']//div[contains(@class,'v-price-box__cur--discount')]/span[@class='sum']";
        private const string itemsOldPriceList = "//div[contains(@class,'v-price-box__old')]";
        public ResultPage(IWebDriver driver) : base(driver) { }

        public void ClickFilterPriceButton()
        {           
            WaitClickability(timeSpan, By.XPath(filterPriceButton));
            var element = driver.FindElement(By.XPath(filterPriceButton));
            if (element.GetAttribute("class").Equals("accordion")) element.Click();
        }
        public List<double> GetItemsDiscountPriceList()
        {
            WaitInvisibility(timeSpan, By.XPath(loadingBlock));
            WaitAllElementsVisibility(timeSpan, By.XPath(itemsDiscountPriceTextList));
            var prices = driver.FindElements(By.XPath(itemsDiscountPriceTextList));
            var temp = prices.Select(price => double.Parse(price.Text)).ToList();
            return temp;
        }
        public IReadOnlyCollection<IWebElement> GetItemsOldPriceList()
        {
            WaitAllElementsVisibility(timeSpan, By.XPath(itemsOldPriceList));
            return driver.FindElements(By.XPath(itemsOldPriceList));
        }
        public IReadOnlyCollection<IWebElement> GetProductCartTitleList()
        {
            WaitAllElementsVisibility(timeSpan, By.XPath(productCartTitleList));
            return driver.FindElements(By.XPath(productCartTitleList));
        }
        public void ClickFilterDiscountCheckbox()
        {
            WaitClickability(timeSpan, By.XPath(filterDiscountCheckbox));
            driver.FindElement(By.XPath(filterDiscountCheckbox)).Click();
        }
        public void EnterPriceRangeFrom(string price)
        {
            WaitClickability(timeSpan, By.XPath(priceRangeFrom));
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(priceRangeFrom)).Clear();
            driver.FindElement(By.XPath(priceRangeFrom)).SendKeys(price);
        }
        public void EnterPriceRangeTo(string price)
        {
            WaitClickability(timeSpan, By.XPath(priceRangeTo));
            driver.FindElement(By.XPath(priceRangeTo)).Clear();
            driver.FindElement(By.XPath(priceRangeTo)).SendKeys(price);
        }
        public void ClickFilterPopupButton()
        {
            WaitVisibility(timeSpan, By.XPath(filterPopupButton));
            driver.FindElement(By.XPath(filterPopupButton)).Click();
        }
        public void ClickItemFromProductCardList(int index)
        {
            WaitInvisibility(timeSpan, By.XPath(loadingBlock));
            WaitAllElementsVisibility(timeSpan, By.XPath(productCardList));
            var resultProductCardList = driver.FindElements(By.XPath(productCardList));
            resultProductCardList[index - 1].Click();
        }
    }
}
