using OpenQA.Selenium;
using System.Threading;

namespace SpecFlowProject.Pages
{
    class NavigationBar : BasePage
    {
        private IWebElement SignUpButton => driver.FindElement(By.XPath("//a[@id='signin2']"));
        private IWebElement LoginButton => driver.FindElement(By.XPath("//a[@id='login2']"));
        private IWebElement WelcomeButton => driver.FindElement(By.XPath("//a[@id='nameofuser']"));
        private IWebElement HomeButton => driver.FindElement(By.XPath("//li[contains(@class,'nav-item')]/a[@href='index.html']"));
        private IWebElement CartButton => driver.FindElement(By.XPath("//li[contains(@class,'nav-item')]/a[@href='cart.html']"));
        private IWebElement LogoutButton => driver.FindElement(By.XPath("//a[@id='logout2']"));
        private IWebElement NavBar => driver.FindElement(By.XPath("//ul[contains(@class,'navbar-nav')]"));

        public NavigationBar(IWebDriver driver) :base(driver) {}

        public SignUpPage ClickSignUpButton()
        {
            WaitClickability(SignUpButton);
            SignUpButton.Click();
            return new SignUpPage(driver);
        }
        public LoginPage ClickLoginButton()
        {
            WaitClickability(LoginButton);
            LoginButton.Click();
            return new LoginPage(driver);
        }
        public bool IsWelcomeButtonDisplayed()
        {
            WaitPageToLoad();
            Thread.Sleep(2000);
            WaitVisibility(NavBar);          
            return WelcomeButton.Displayed;
        }
        public string GetWelcomeButtonText()
        {           
            return WelcomeButton.Text;
        }
        public HomePage ClickHomeButton()
        {
            WaitClickability(HomeButton);
            HomeButton.Click();
            return new HomePage(driver);
        }
        public CartPage ClickCartButton()
        {
            WaitClickability(CartButton);
            CartButton.Click();
            return new CartPage(driver);
        }
        public void ClickLogoutButton()
        {
            WaitClickability(LogoutButton);
            LogoutButton.Click();
        }
    }
}
