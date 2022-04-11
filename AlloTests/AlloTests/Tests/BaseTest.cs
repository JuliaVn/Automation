using AlloTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace AlloTests
{
    public class BaseTest
    {
        private IWebDriver driver;
        private static readonly string pathChromeDriver = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private const string url = "https://allo.ua/";

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-notifications");
            options.AddArguments("--disable-application-cache");
            driver = new ChromeDriver(pathChromeDriver, options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void TearDown()
        {      
            driver.Quit();
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }
        public HomePage GetHomePage()
        {
            return new HomePage(GetDriver());
        }
        public ResultPage GetResultPage()
        {
            return new ResultPage(GetDriver());
        }
        public ProductPage GetProductPage()
        {
            return new ProductPage(GetDriver());
        }
        public CartPopupPage GetCartPopupPage()
        {
            return new CartPopupPage(GetDriver());
        }
    }
}