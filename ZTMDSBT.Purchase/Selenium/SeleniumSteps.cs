using System;
using System.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using ZTMDSBT.Purchase.Models;

namespace ZTMDSBT.Purchase.Selenium
{
  internal class SeleniumSteps
  {
    private IWebDriver _driver;

    public SeleniumSteps(IWebDriver driver)
    {
      _driver = driver;
    }

    public SeleniumSteps Login(User user)
    {
      _driver.Navigate();
      _driver.ExecuteJavaScript<string>("$('.login-text').click()");
      var emailInput = _driver.FindElement(By.Id("exp-login-email_modal"));

      emailInput.SendKeys(user.Username);

      var pwdInput = _driver.FindElement(By.Id("exp-login-password_modal"));
      pwdInput.Clear();
      pwdInput.SendKeys(user.Password);
      var submit = _driver.FindElement(By.ClassName("exp-login-submit"));
      submit.Click();
      return this;
    }

    public SeleniumSteps GotoProductPage(string url)
    {
      _driver.Navigate().GoToUrl(url);
      return this;
    }

    public SeleniumSteps WaitUntilZero()
    {
      var wait = new WebDriverWait(_driver, new TimeSpan(1, 0, 0));
      wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
      wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
      wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("buyingtools-add-to-cart-button")));
      return this;
    }

    public SeleniumSteps SelectSizeAndQuantity(Product product)
    {
      //      var selectContainer = _driver.FindElements(By.ClassName("exp-pdp-size-container")).FirstOrDefault(e => e.Displayed);
      var selectContainer =
        _driver.FindElement(By.CssSelector(".exp-pdp-size-and-quantity-container > div:nth-child(1)"));
      selectContainer.Click();

      var sizeOption =
        _driver.ExecuteJavaScript<IWebElement>(
          "return $('ul.nsg-form--drop-down--option-container:nth-child(1)>li:contains(\\'" + product.Size + "\\')')[0]");

      // should change to stock check.
      if (sizeOption.GetAttribute("class").Contains("selectBox-disabled"))
      {
        MessageBox.Show("out of stock.");
        return null;
      }
      sizeOption.Click();
      return this;

      // don't choose quantity for now.
      //      var quantityOption =
      //        _driver.ExecuteJavaScript<IWebElement>("return $('ul.exp-pdp-quantity-dropdown > li:contains(1)')");
      //      quantityOption.Click();
    }

    public SeleniumSteps AddedToCart()
    {
      var addToCart = _driver.FindElement(By.Id("buyingtools-add-to-cart-button"));
      addToCart.Click();
      var wait = new WebDriverWait(_driver, new TimeSpan(1, 0, 0));
      var success = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("minicart-view-cart-button")));
      success.Click();
      return this;
    }

    public SeleniumSteps CreateOrder()
    {
      GotoCheckout();
      FillPaymentGetway();
      //      FillInvoceInfo();
      Checkout();
      Confirm();
      return this;
    }

    private void Confirm()
    {
      var confirm = _driver.FindElement(By.ClassName("ch4_btnPlaceOrder"));
      confirm.Click();
    }

    private void GotoCheckout()
    {
      var wait = new WebDriverWait(_driver, new TimeSpan(1, 0, 0));
      wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
      if (wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("pageLoader"))))
      {
        var checkout = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ch4_cartCheckoutBtn")));
        checkout.Click();
      }
    }

    private void FillPaymentGetway()
    {
      var aliapy = _driver.FindElement(By.CssSelector("[for=alipay]"));
      aliapy.Click();
    }

    private void FillInvoceInfo()
    {
      var needInvoce = _driver.FindElement(By.CssSelector("[for=fapiaoFlag]"));
      needInvoce.Click();
      var infoceTitle = _driver.FindElement(By.CssSelector("[name=fapiaoTitle]"));
      infoceTitle.SendKeys("xxxxxxxxxxx");
    }

    private void Checkout()
    {
      var next = _driver.FindElement(By.Id("billingSubmit"));
      next.Click();
    }
  }
}
