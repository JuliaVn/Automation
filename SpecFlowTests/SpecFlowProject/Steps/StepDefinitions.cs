using OpenQA.Selenium;
using NUnit.Framework;
using SpecFlowProject.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps
{
    [Binding]
    public sealed class StepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        HomePage homePage;
        SignUpPage signUpPage;
        LoginPage loginPage;
        ProductPage productPage;
        CartPage cartPage;
        NavigationBar navigationBar;
        PlaceOrderPage placeOrderPage;

        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = Hooks.Hooks.Driver;
        }

        [Given(@"User opens the '(.*)' page")]
        public void UserOpensPage(string url)
        {
            if (_driver.Url == url) return; 
            _driver.Navigate().GoToUrl(url); 
        }

        [Given(@"User clicks the Sign Up button")]
        public void UserClicksSignUpButton()
        {
            navigationBar = new NavigationBar(_driver);
            signUpPage = navigationBar.ClickSignUpButton();
        }

        [When(@"User enters '(.*)' and '(.*)' on the Sign up Page")]
        public void UserEntersDataOnSignUpPage(string userName, string password)
        {
            signUpPage.SignUpNewUser(userName, password);
        }

        [Then(@"User checks that the alert appears with the message '(.*)'")]
        public void UserChecksThatAlertAppearsWithMessage(string message)
        {
            Assert.That(_driver.SwitchTo().Alert().Text.Equals(message));
        }

        [Then(@"User closes the Sign Up popup")]
        public void UserClosesSignUpPopup()
        {
            _driver.SwitchTo().Alert().Accept();
            signUpPage.ClickCloseButton();
            navigationBar = new NavigationBar(_driver);
            navigationBar.ClickHomeButton();
        }

        [Given(@"User clicks the Log in button")]
        public void UserClicksLogInButton()
        {
            navigationBar = new NavigationBar(_driver);
            loginPage = navigationBar.ClickLoginButton();
        }

        [When(@"User enters '(.*)' and '(.*)' on the Login Page")]
        public void UserEntersDataOnLoginPage(string userName, string password)
        {
            loginPage.LoginUser(userName, password);
        }

        [Then(@"User checks that the login was successful and that the '(.*)' appears")]
        public void UserChecksThatLoginWasSuccessful(string userName)
        {
            Assert.That(navigationBar.IsWelcomeButtonDisplayed());
            Assert.That(navigationBar.GetWelcomeButtonText().Contains(userName));
        }

        [Then(@"User Log out")]
        public void UserLogOut()
        {
            navigationBar.ClickLogoutButton();
        }

        [When(@"User clicks on the '(.*)' category")]
        public void UserClicksOnCategory(string category)
        {
            homePage = new HomePage(_driver);
            homePage.ClickCategory(category);
        }

        [When(@"User clicks on the first product")]
        public void UserClicksOnFirstProduct()
        {
            productPage = homePage.ClickFirstProduct();
        }

        [When(@"User clicks Add to Cart button")]
        public void UserClicksAddToCartButton()
        {
            productPage.ClickAddToCartButton();           
        }

        [When(@"User comebacks to the Home page")]
        public void UserComebacksToHomePage()
        {
            navigationBar = new NavigationBar(_driver);
            navigationBar.ClickHomeButton();
        }

        [When(@"User clicks on the Cart button")]
        public void UserClicksOnCartButton()
        {
            cartPage = navigationBar.ClickCartButton();
        }

        [Then(@"User checks that items amount in the Cart is '(.*)'")]
        public void UserChecksItemsAmountInTheCart(int amount)
        {
            Assert.That(cartPage.GetProductItemsSize().Equals(amount));
        }

        [Then(@"User clicks the Place Order button")]
        public void ThenUserClicksThePlaceOrderButton()
        {
            placeOrderPage = cartPage.ClickPlaceOrderButton();
        }

        [Then(@"User fills out the '(.*)' and '(.*)' data")]
        public void ThenUserFillsOutTheAndData(string name, string card)
        {
            placeOrderPage.FillOutData(name, card);
        }

        [Then(@"User clicks the Purchase button")]
        public void ThenUserClicksThePurchaseButton()
        {
            placeOrderPage.ClickPurchaseButton();
        }

        [Then(@"User checks that the purchase info is displayed and equal to '(.*)'")]
        public void UserChecksThatPurchaseInfoIsDisplayedAndEqualToText(string text)
        {
            Assert.IsTrue(placeOrderPage.IsPurchaseInfoDisplayed());
            Assert.That(text.Equals(placeOrderPage.GetPurchaseInfoText()));
        }
    }
}