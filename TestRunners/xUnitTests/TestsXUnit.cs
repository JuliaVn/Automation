using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Reflection;
using System.Linq;

namespace xUnitTests
{
    public class TestsXUnit : IDisposable
    {
        private IWebDriver driver;
        private static readonly string pathChromeDriver = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private const string url = "https://xunit.net/";

        private const string logo = "//div[@class='navbar-header']/descendant::img";
        private const string tableOFContentSection = "//*[contains(text(),'Table of Contents')]";
        private const string tableOFContentOptions = "div > ul:first-of-type >li > a";
        private const string keyword = "Documentation";

        public TestsXUnit()
        {
            driver = new ChromeDriver(pathChromeDriver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [Fact]
        public void CheckLogoIsPresent()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(drv => drv.FindElement(By.XPath(logo)).Displayed);
            Assert.True(driver.FindElement(By.XPath(logo)).Displayed);
        }
        [Fact]
        public void CheckTableOfContextSectionContainsDocumentation()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(drv => drv.FindElement(By.XPath(tableOFContentSection)).Displayed);
            var options = driver.FindElements(By.CssSelector(tableOFContentOptions)).Select(element => element.Text).ToList();
            Assert.Contains(keyword, options);
        }
        public void Dispose()
        {
            driver.Quit();
        }
    }
}
