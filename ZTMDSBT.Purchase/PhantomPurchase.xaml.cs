using System;
using System.Collections.Generic;
//www.nike.com/profile/login?Content-Locale=zh_CN
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Extensions.MonoHttp;
using ZTMDSBT.Purchase.Models;
using ZTMDSBT.Purchase.Selenium;
using ZTMDSBT.Purchase.Service;
using DataFormat = RestSharp.DataFormat;

namespace ZTMDSBT.Purchase
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class PhantomPurchase : Window
  {


    public PhantomPurchase()
    {
      InitializeComponent();
      Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {

    }
    private void BtnGetProduct_click(object sender, RoutedEventArgs e)
    {
      var product = PurchaseConfiguration.GetProduct();
      product.GetProductInfo(ApplicationContext.Context.LoginedUsers.First().Cookies);
      MessageBox.Show(
        string.Format("Instock:{0}, Outstock:{1}",
          product.ProductSkus.Where(s => s.InStock)
            .Aggregate(string.Empty, (result, next) => result += (next.DisplaySize + ";")),
          product.ProductSkus.Where(s => !s.InStock)
            .Aggregate(string.Empty, (result, next) => result += next.DisplaySize + ";")));
    }

    private void BtnLogin_click(object sender, RoutedEventArgs e)
    {
      var user = PurchaseConfiguration.GetUser();
      if (user.Login())
      {
        ApplicationContext.Context.LoginedUsers.Add(user);
        MessageBox.Show("logined!");
        return;
      }
      MessageBox.Show("login failed!");
    }
  }
}