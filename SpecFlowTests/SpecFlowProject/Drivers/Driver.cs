using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SpecFlowProject.Drivers
{
    //public class DriverFixture
    //{
    //    private readonly IWebDriver _driver;
    //    private static readonly string pathChromeDriver = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    //    public DriverFixture()
    //    {
    //        _driver = GetDriver();
    //    }

    //    public IWebDriver Driver => _driver;

    //    private IWebDriver GetDriver()
    //    {
    //        ChromeOptions options = new ChromeOptions();
    //        options.AddArguments("--disable-extensions");
    //        options.AddArguments("--disable-notifications");
    //        options.AddArguments("--disable-application-cache");
    //        return new ChromeDriver(pathChromeDriver, options);
    //    }
    //}
}
