using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;

namespace AlloTests.Pages
{
    public class CartPopupPage : BasePage
    {
        private static readonly TimeSpan timeSpan = TimeSpan.FromSeconds(30);
        private const string cartPopup = "//div[contains(@class,'v-modal__cmp cart-popup')]";
        private const string lastProductTitleName = "(//div[@class='title']//span)[last()]";
        private const string lastProductPrice = "(//div[@class='price-box__cur'])[last()]";
        private const string totalPrice = "//span[@class='total-box__price']";
        private const string comeback = "//button[@class='comeback']";
        private const string cartPopupCloseButton = "//div[@class='v-modal__close-btn']";

        public CartPopupPage(IWebDriver driver) : base(driver) { }

        public IWebElement GetCartPopup()
        {
            WaitVisibility(timeSpan, By.XPath(cartPopup));
            return driver.FindElement(By.XPath(cartPopup));
        }
        public string GetLastProductTitleName()
        {
            WaitVisibility(timeSpan, By.XPath(lastProductTitleName));
            return driver.FindElement(By.XPath(lastProductTitleName)).Text;
        }
        public double GetLastProductPrice()
        {
            WaitVisibility(timeSpan, By.XPath(lastProductPrice));
            string price = driver.FindElement(By.XPath(lastProductPrice)).Text;
            var regex = new Regex(@" ₴$");
            return double.Parse(regex.Replace(price, ""));
        }
        public double GetTotalPrice()
        {
            WaitVisibility(timeSpan, By.XPath(totalPrice));
            string price = driver.FindElement(By.XPath(totalPrice)).Text;
            var regex = new Regex(@" ₴$");
            return double.Parse(regex.Replace(price, ""));
        }
        public void ClickComebackButton()
        {
            WaitClickability(timeSpan, By.XPath(comeback));
            driver.FindElement(By.XPath(comeback)).Click();
        }
        public void CloseCartPopup()
        {
            WaitClickability(timeSpan, By.XPath(cartPopupCloseButton));
            driver.FindElement(By.XPath(cartPopupCloseButton)).Click();
        }
    }
}
