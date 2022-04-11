using OpenQA.Selenium;
using System;

namespace AlloTests.Pages
{
    public class CartPopupPage : BasePage
    {
        private static readonly TimeSpan timeSpan = TimeSpan.FromSeconds(30);
        private const string cartPopup = "//div[contains(@class,'v-modal__cmp cart-popup')]";
        private const string orderNow = "//button[@class='order-now']";
        private const string comeback = "//button[@class='comeback']";
        private const string cartPopupCloseButton = "//div[@class='v-modal__close-btn']";

        public CartPopupPage(IWebDriver driver) : base(driver) { }

        public IWebElement GetCartPopup()
        {
            WaitVisibility(timeSpan, By.XPath(cartPopup));
            return driver.FindElement(By.XPath(cartPopup));
        }
        public IWebElement GetOrderNowButton()
        {
            WaitVisibility(timeSpan, By.XPath(orderNow));
            return driver.FindElement(By.XPath(orderNow));
        }
        public IWebElement GetComebackButton()
        {
            WaitVisibility(timeSpan, By.XPath(comeback));
            return driver.FindElement(By.XPath(comeback));
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
