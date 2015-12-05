using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using SeleniumWebdriverHelpers;

namespace ZTMDSBT.Purchase
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void button_Click(object sender, RoutedEventArgs e)
    {
      IWebDriver driver = new FirefoxDriver() { Url = "http://www.nike.com/cn/zh_cn/" };

      driver.Navigate();
      //      driver.FindElement(By.ClassName("exp-join-login")).Click();
      //      driver.FindElement(By.ClassName("login-text")).Click();
      //      driver.FindElement(By.ClassName("exp-join-login")).FindElement(By.CssSelector("a")).Click();
      driver.ExecuteJavaScript<String>("$('.login-text').click()");
//      driver.ExecuteJavaScript<String>("$('.modal-mask-class').show()");
//      driver.ExecuteJavaScript<String>("$('.modal-window-class').eq(1).show()");
      var emailInput = driver.FindElement(By.Id("exp-login-email_modal"));

      emailInput.SendKeys("278325177@qq.com");

      var pwdInput = driver.FindElement(By.Id("exp-login-password_modal"));
      pwdInput.Clear();
      pwdInput.SendKeys("Qwer0987");
      var submit = driver.FindElement(By.ClassName("exp-login-submit"));
      submit.Click();
      // use wait for ajax replace thread sleep.
      driver.WaitForAjax();
      Screenshot screen = driver.TakeScreenshot();
      screen.SaveAsFile("./baidu_search2.png", ImageFormat.Png);
      MessageBox.Show("ok!");
      //      driver.Quit();
    }
  }
}
