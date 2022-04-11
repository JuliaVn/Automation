using NUnit.Framework;
using System;


namespace AlloTests.Tests
{
    class Tests : BaseTest
    {
        private static readonly TimeSpan timeSpan = TimeSpan.FromSeconds(30);
        private const string expectedUrlRuLang = "https://allo.ua/ru/";
        private const string language = "ru";
        private const string city = "Дніпро";
        private const string keyword = "lg";
        private const int numberOfItemFromList = 1;
        private const int secondNumberOfItemFromList = 2;
        private const string priceFrom = "500";
        private const string priceTo = "12000";
        private const string keywordPhone = "LG G8 ThinQ 1 sim 6/128Gb Red";
        private const string color = "Black";
        private const string numberOfProductsInCart = "2";

        [Test]
        public void CheckLanguageSwitchingWorksCorrectly()
        {
            GetHomePage().WaitPageToLoad(timeSpan);
            GetHomePage().SwitchLanguage(language.ToUpper());
            GetHomePage().WaitPageToLoad(timeSpan); 
            GetHomePage().WaitUntilUrlToBe(timeSpan, expectedUrlRuLang);
            Assert.IsTrue(GetDriver().Url.Contains(language.ToLower()));
        }

        [Test]
        public void CheckCitySwitchingWorksCorrectly()
        {
            GetHomePage().WaitPageToLoad(timeSpan);
            GetHomePage().ClickCityButton();
            GetHomePage().ClickCityLink(city);
            Assert.IsTrue(GetHomePage().GetLocationLabel().Contains(city));
            GetHomePage().ClickCityButton();
            Assert.IsTrue(GetHomePage().GetSelectedCity().Contains(city));
        }
        [Test]
        public void SearchByKeyword()
        {
            GetHomePage().WaitPageToLoad(timeSpan);
            GetHomePage().EnterKeywordToSearch(keyword);
            GetHomePage().ClickItemFromSearchPopup(numberOfItemFromList);
            foreach (var title in GetResultPage().GetProductCartTitleList())
            {
                Assert.IsTrue(title.Text.ToLower().Contains(keyword));
            }
        }
        [Test]
        public void CheckFilterWorksCorrectly()
        {
            GetHomePage().WaitPageToLoad(timeSpan);
            GetHomePage().EnterKeywordToSearch(keyword);
            GetHomePage().ClickItemFromSearchPopup(numberOfItemFromList);
            GetResultPage().ScrollBy();
            GetResultPage().WaitPageToLoad(timeSpan);
            GetResultPage().ClickFilterDiscountCheckbox();
            GetResultPage().ClickFilterPopupButton();
            //GetResultPage().ScrollBy(); //why it doesn't work here???
            GetResultPage().EnterPriceRangeFrom(priceFrom);
            GetResultPage().EnterPriceRangeTo(priceTo);
            GetResultPage().ClickFilterPopupButton();
            GetResultPage().ClickItemFromProductCardList(numberOfItemFromList);
            Assert.IsTrue(GetProductPage().GetProductViewTitle().ToLower().Contains(keyword));
            Assert.That(double.Parse(GetProductPage().GetCurrentProductPrice()),
                Is.InRange(double.Parse(priceFrom), double.Parse(priceTo)));
        }
        [Test]
        public void CheckColorHasBeenChanged()
        {
            GetHomePage().WaitPageToLoad(timeSpan);
            GetHomePage().SearchByKeyword(keywordPhone);
            GetResultPage().WaitPageToLoad(timeSpan);
            GetResultPage().ClickItemFromProductCardList(numberOfItemFromList);
            GetProductPage().SwitchColor(color);
            Assert.IsTrue(GetProductPage().GetProductViewTitle().Contains(color));
            Assert.IsTrue(GetProductPage().GetColorLabelTitle().Contains(color));
        }
        [Test]
        public void CheckAddingToCart()
        {
            GetHomePage().WaitPageToLoad(timeSpan);
            GetHomePage().SearchByKeyword(keyword);
            GetResultPage().WaitPageToLoad(timeSpan);
            GetResultPage().ClickItemFromProductCardList(numberOfItemFromList);
            GetResultPage().WaitPageToLoad(timeSpan);
            GetProductPage().ClickProductBuyButton();
            Assert.IsTrue(GetCartPopupPage().GetCartPopup().Displayed);
            Assert.IsTrue(GetCartPopupPage().GetOrderNowButton().Displayed);
            Assert.IsTrue(GetCartPopupPage().GetComebackButton().Displayed);
            GetCartPopupPage().ClickComebackButton();
            GetProductPage().ComebackToPreviousPage();
            GetResultPage().WaitPageToLoad(timeSpan);
            GetResultPage().ClickItemFromProductCardList(secondNumberOfItemFromList);
            GetProductPage().ClickProductBuyButton();
            Assert.IsTrue(GetCartPopupPage().GetCartPopup().Displayed);
            Assert.IsTrue(GetCartPopupPage().GetOrderNowButton().Displayed);
            Assert.IsTrue(GetCartPopupPage().GetComebackButton().Displayed);
            GetCartPopupPage().CloseCartPopup();
            Assert.AreEqual(numberOfProductsInCart, GetProductPage().GetCartIconText());
        }
    }
}
