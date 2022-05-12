using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Threading;

namespace SpecFlowProject.Pages
{
    class CartPage : BasePage
    {
        private ReadOnlyCollection<IWebElement> ProductItemsList => driver.FindElements(By.XPath("//tr[@class='success']"));
        private IWebElement PlaceOrderButton => driver.FindElement(By.XPath("//button[contains(@class,'btn-success')]"));
        private IWebElement CartTable => driver.FindElement(By.XPath("//tbody[@id='tbodyid']"));

        public CartPage(IWebDriver driver) : base(driver) {}

        public int GetProductItemsSize()
        {
            Thread.Sleep(2000);
            WaitVisibility(CartTable);
            return ProductItemsList.Count;
        }
        public PlaceOrderPage ClickPlaceOrderButton()
        {
            WaitClickability(PlaceOrderButton);
            PlaceOrderButton.Click();
            return new PlaceOrderPage(driver);
        }
    }
}
