using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading;
using System.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using SeleniumWebdriverHelpers;

namespace ZTMDSBT.Purchase
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
      _driver.WaitForAjax();
      return this;
    }

    public SeleniumSteps GotoProductPage(string url)
    {
      _driver.Url = url;
      _driver.Navigate();
      return this;
    }

    public SeleniumSteps SelectSizeAndQuantity(Product product)
    {
      //      var selectContainer = _driver.FindElements(By.ClassName("exp-pdp-size-container")).FirstOrDefault(e => e.Displayed);
      var selectContainer =
        _driver.FindElement(By.CssSelector(".exp-pdp-size-and-quantity-container > div:nth-child(1)"));
      selectContainer.Click();
      Thread.Sleep(200);

      var sizeOption =
        _driver.ExecuteJavaScript<IWebElement>(
          "return $('ul.nsg-form--drop-down--option-container:nth-child(1)>li:contains(\\'" + product.Size + "\\')')[0]");

      // should change to stock check.
      if (sizeOption == null)
      {
        MessageBox.Show("out of stock.");
        return null;
      }
      sizeOption.Click();

      // don't choose quantity for now.
      //      var quantityOption =
      //        _driver.ExecuteJavaScript<IWebElement>("return $('ul.exp-pdp-quantity-dropdown > li:contains(1)')");
      //      quantityOption.Click();
      return this;
    }

    public SeleniumSteps AddedToCart()
    {
      var addToCart = _driver.FindElement(By.Id("buyingtools-add-to-cart-button"));
      addToCart.Click();
      _driver.WaitForAjax();
      return this;
    }

    public SeleniumSteps CreateOrder()
    {
      GotoCheckout();
      FillPaymentGetway();
      FillInvoceInfo();
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
      Thread.Sleep(200);
      var cartButton = _driver.FindElement(By.ClassName("gnav-member-bar--cart-icon"));
      cartButton.Click();
      _driver.WaitForAjax();
      var checkout = _driver.FindElement(By.LinkText("结算"));
      checkout.Click();
      _driver.WaitForAjax();
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
      _driver.WaitForAjax();
    }

  }
}
