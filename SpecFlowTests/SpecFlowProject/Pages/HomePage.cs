using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Threading;

namespace SpecFlowProject.Pages
{
    class HomePage : BasePage
    {
        private IWebElement Category(string category) =>
            driver.FindElement(By.XPath($"//div[@class='list-group']/a[text()='{category}']"));
        private ReadOnlyCollection<IWebElement> ProductsList => driver.FindElements(By.XPath("//a[@class='hrefch']"));
        private IWebElement ItemsTable => driver.FindElement(By.XPath("//div[@id='tbodyid']"));
        
        public HomePage(IWebDriver driver) : base(driver) {}

        public void ClickCategory(string category)
        {
            WaitClickability(Category(category));
            Category(category).Click();
            WaitPageToLoad();
        }
        public ProductPage ClickFirstProduct()
        {
            Thread.Sleep(3000);
            WaitVisibility(ItemsTable);
            WaitClickability(ProductsList[0]);
            ProductsList[0].Click();
            return new ProductPage(driver);
        }
    }
}
