using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Linq;

namespace MSTests
{
    [TestClass]
    public class TestsMSTest
    {
        private IWebDriver driver;
        private static readonly string pathChromeDriver = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private const string url = "https://xunit.net/";

        private const string logo = "//div[@class='navbar-header']/descendant::img";
        private const string tableOFContentSection = "//*[contains(text(),'Table of Contents')]";
        private const string tableOFContentOptions = "div > ul:first-of-type >li > a";
        private const string keyword = "Documentation";

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver(pathChromeDriver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }
        [TestMethod]
        public void CheckLogoIsPresent()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(drv => drv.FindElement(By.XPath(logo)).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath(logo)).Displayed);
        }
        [TestMethod]
        public void CheckTableOfContextSectionContainsDocumentation()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(drv => drv.FindElement(By.XPath(tableOFContentSection)).Displayed);
            var options = driver.FindElements(By.CssSelector(tableOFContentOptions)).Select(element => element.Text).ToList();
            Assert.IsTrue(options.Contains(keyword));
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
