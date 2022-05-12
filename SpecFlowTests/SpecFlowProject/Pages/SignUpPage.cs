using OpenQA.Selenium;

namespace SpecFlowProject.Pages
{
    class SignUpPage : BasePage
    {
        private IWebElement UserNameField => driver.FindElement(By.CssSelector("body.modal-open > div:nth-of-type(2) input#sign-username"));
        private IWebElement PasswordField => driver.FindElement(By.CssSelector("body.modal-open > div:nth-of-type(2) input#sign-password"));
        private IWebElement SignUpButton => driver.FindElement(By.CssSelector("body.modal-open > div:nth-of-type(2) button.btn-primary"));
        private IWebElement CloseButton => driver.FindElement(By.CssSelector("body.modal-open > div:nth-of-type(2) button.btn-secondary"));

        public SignUpPage(IWebDriver driver) : base(driver) {}

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
        public void SignUpNewUser(string name, string pasword)
        {
            EnterUserName(name);
            EnterPassword(pasword);
            SignUpButton.Click();
            WaitAlertIsPresent();
        }
        public void ClickCloseButton()
        {
            WaitClickability(CloseButton);
            CloseButton.Click();
        }
    }
}
