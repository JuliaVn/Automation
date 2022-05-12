using OpenQA.Selenium;
using System.Threading;

namespace SpecFlowProject.Pages
{
    class ProductPage : BasePage
    {
        private const string urlText = "prod.html";
        private IWebElement AddToCartButton => driver.FindElement(By.XPath("//a[contains(@class,'btn')]"));
        private IWebElement ProductDescription => driver.FindElement(By.XPath("//div[@id='tbodyid']"));
        private IWebElement ButtonSection => driver.FindElement(By.XPath("//div[@id='tbodyid']/div[@class='row']"));

        public ProductPage(IWebDriver driver) : base(driver) {}

        public void ClickAddToCartButton()
        {
            WaitUrlContains(urlText);
            WaitPageToLoad();
            WaitVisibility(ProductDescription);
            Thread.Sleep(2000);
            WaitVisibility(ButtonSection);
            WaitClickability(AddToCartButton);
            AddToCartButton.Click();
            WaitAlertIsPresent();
            driver.SwitchTo().Alert().Accept();
        }     
    }
}
