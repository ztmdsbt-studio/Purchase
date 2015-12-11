using System;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Windows;
using CsQuery.ExtensionMethods;
using CsQuery.ExtensionMethods.Internal;
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

    public SeleniumSteps SelectSizeAndQuantity()
    {
      var selectContainer = _driver.FindElements(By.ClassName("exp-pdp-size-container")).FirstOrDefault(e => e.Displayed);
      selectContainer.Click();
      var sizeSelector = selectContainer.FindElement(By.TagName("ul"));
      Thread.Sleep(200);
      var option =
        sizeSelector.FindElements(By.TagName("option"))
          .FirstOrDefault(e => e.GetAttribute("data-label") == "(" + 46 + ")"
                            && !e.GetAttribute("class").Contains("exp-pdp-size-not-in-stock")
                            && e.Displayed);
      if (option == null)
      {
        MessageBox.Show("out of stock.");
        return null;
      }
      option.Click();
      return this;
    }

    public SeleniumSteps AddedToCart()
    {
      throw new NotImplementedException();
    }

    public SeleniumSteps CreateOrder()
    {
      throw new NotImplementedException();
    }

    public SeleniumSteps FillPaymentGetwayAndOtherInfo()
    {
      throw new NotImplementedException();
    }
  }
}
