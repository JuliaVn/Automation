using OpenQA.Selenium;

namespace SpecFlowProject.Pages
{
    class LoginPage : BasePage
    {
        private IWebElement UserNameField => driver.FindElement(By.CssSelector("body.modal-open > div:nth-of-type(3) input#loginusername"));
        private IWebElement PasswordField => driver.FindElement(By.CssSelector("body.modal-open > div:nth-of-type(3) input#loginpassword"));
        private IWebElement LoginButton => driver.FindElement(By.CssSelector("body.modal-open > div:nth-of-type(3) button.btn-primary"));

        public LoginPage(IWebDriver driver) : base(driver) {}

        public void EnterUserName(string name)
        {
            WaitPageToLoad();
            WaitClickability(UserNameField);
            UserNameField.Clear();
            UserNameField.SendKeys(name);
        }
        public void EnterPassword(string password)
        {
            WaitClickability(PasswordField);
            PasswordField.Clear();
            PasswordField.SendKeys(password);
        }
        public void LoginUser(string name, string pasword)
        {
            EnterUserName(name);
            EnterPassword(pasword);
            LoginButton.Click();
        }
    }
}
