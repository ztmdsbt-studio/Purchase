using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ZTMDSBT.Purchase
{
  public static class WebElementExtend
  {
    public static void SupperClick(this IWebElement selectContainer)
    {
      var needClick = true;
      while (needClick)
      {
        try
        {
          selectContainer.Click();
          needClick = false;
        }
        finally
        {
          Thread.Sleep(100);
        }
      }
    }
  }
}
