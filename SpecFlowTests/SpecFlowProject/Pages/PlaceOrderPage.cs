using OpenQA.Selenium;

namespace SpecFlowProject.Pages
{
    class PlaceOrderPage : BasePage
    {
        private IWebElement NameField => driver.FindElement(By.XPath("//input[(@id='name')]"));
        private IWebElement CreditCardField => driver.FindElement(By.XPath("//input[(@id='card')]"));
        private IWebElement PurchaseButton => driver.FindElement(By.CssSelector("body.modal-open > div:nth-of-type(3) button.btn-primary"));
        private IWebElement PurchaseInfo => driver.FindElement(By.XPath("//div[contains(@class,'sweet-alert')]/h2"));
        private IWebElement PurchasePopup => driver.FindElement(By.XPath("//div[contains(@class,'sweet-alert')]"));

        public PlaceOrderPage(IWebDriver driver) : base(driver) {}

        public void EnterName(string name)
        {
            WaitPageToLoad();
            WaitClickability(NameField);
            NameField.Clear();
            NameField.SendKeys(name);
        }
        public void EnterCreditCard(string card)
        {
            WaitClickability(CreditCardField);
            CreditCardField.Clear();
            CreditCardField.SendKeys(card);
        }
        public void FillOutData(string name, string card)
        {
            EnterName(name);
            EnterCreditCard(card);
        }
        public void ClickPurchaseButton()
        {
            WaitClickability(PurchaseButton);
            PurchaseButton.Click();
        }
        public bool IsPurchaseInfoDisplayed()
        {
            WaitVisibility(PurchasePopup);
            return PurchaseInfo.Displayed;
        }
        public string GetPurchaseInfoText()
        {
            return PurchaseInfo.Text;
        }
    }
}
