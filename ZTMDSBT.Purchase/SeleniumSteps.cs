using System;
using System.Collections.Generic;
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
      var submitButton = _driver.FindElement(By.Id("buyingtools-add-to-cart-button"));
      submitButton.Click();
      _driver.WaitForAjax();
      return this;
    }

    public SeleniumSteps CreateOrder()
    {
      var checkout = _driver.FindElement(By.LinkText("结算"));
      checkout.Click();
      _driver.WaitForAjax();
      return this;
    }

    public SeleniumSteps FillPaymentGetwayAndOtherInfo()
    {
      throw new NotImplementedException();
    }
  }
}
