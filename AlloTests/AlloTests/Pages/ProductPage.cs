using OpenQA.Selenium;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AlloTests.Pages
{
    public class ProductPage : BasePage
    {
        private static readonly TimeSpan timeSpan = TimeSpan.FromSeconds(30);
        private const string productPriceOldText = "//div[contains(@class,'p-trade-price__old')]/span[@class='sum']";
        private const string productPriceCurrentText = "//div[contains(@class,'p-trade-price__current')]/span";
        private const string productViewTitle = "//h1[@class='p-view__header-title']";
        private const string productColorLinkList = "//a[contains(@class,'p-attributes-color__link')]";
        private const string colorSectionLabel = "//span[@class='title__label']";
        private const string productBuyButton = "//button[@id='product-buy-button']";
        private const string lastCrumbsLink = "(//a[@class='b-crumbs__link'])[last()]";
        private const string cartIconText = "//span[@class='c-counter__text']";

        public ProductPage(IWebDriver driver) : base(driver) { }

        public string GetProductViewTitle()
        {
            WaitVisibility(timeSpan, By.XPath(productViewTitle));
            return driver.FindElement(By.XPath(productViewTitle)).Text;
        }
        public double GetCurrentProductPrice()
        {
            WaitVisibility(timeSpan, By.XPath(productPriceCurrentText));
            string price = driver.FindElement(By.XPath(productPriceCurrentText)).Text;
            var regex = new Regex(@" ₴$");
            return double.Parse(regex.Replace(price, ""));
        }
        public double GetOldProductPrice()
        {
            WaitVisibility(timeSpan, By.XPath(productPriceOldText));
            return double.Parse(driver.FindElement(By.XPath(productPriceOldText)).Text);
        }
        public void SwitchColor(string color)
        {
            WaitAllElementsVisibility(timeSpan, By.XPath(productColorLinkList));
            var resultProductColorLinkList = driver.FindElements(By.XPath(productColorLinkList));
            resultProductColorLinkList.Where(link => link.Text.Contains(color)).ToList().ForEach(link => link.Click());
        }
        public string GetColorLabelTitle()
        {
            WaitVisibility(timeSpan, By.XPath(colorSectionLabel));
            return driver.FindElement(By.XPath(colorSectionLabel)).Text;
        }
        public void ClickProductBuyButton()
        {
            WaitClickability(timeSpan, By.XPath(productBuyButton));
            driver.FindElement(By.XPath(productBuyButton)).Click();
        }
        public void ComebackToPreviousPage()
        {
            WaitClickability(timeSpan, By.XPath(lastCrumbsLink));
            driver.FindElement(By.XPath(lastCrumbsLink)).Click();
        }
        public string GetCartIconText()
        {
            WaitVisibility(timeSpan, By.XPath(cartIconText));
            return driver.FindElement(By.XPath(cartIconText)).Text;
        }
    }
}
