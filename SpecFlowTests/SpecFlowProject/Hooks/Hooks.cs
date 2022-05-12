using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private static IWebDriver driver;
        private static readonly string _pathChromeDriver = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [BeforeFeature]
        public static void BeforeFeature()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-notifications");
            options.AddArguments("--disable-application-cache");
            driver =  new ChromeDriver(_pathChromeDriver, options);
            driver.Manage().Window.Maximize();           
        }
        [AfterFeature]
        public static void AfterFeature()
        {
            driver.Quit();
        }         
        public static IWebDriver Driver => driver;
    }
} 
