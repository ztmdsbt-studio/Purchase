using System;
using System.Collections.Generic;
//www.nike.com/profile/login?Content-Locale=zh_CN
using System.IO;
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

    private IList<RestResponseCookie> cookies;

    public PhantomPurchase()
    {
      InitializeComponent();
      Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {

    }

    private void button_Click(object sender, RoutedEventArgs e)
    {
      var user = PurchaseConfiguration.GetUser();
      var client = new RestClient(Consts.BaseUrl);
      var request = Request.Login(user);
      var response = client.Execute(request);
      var content = response.Content;
      cookies = response.Cookies;
      request.AddCookie(cookies[0].Name, cookies[0].Value);
      request  = new RestRequest("/pd/kd-8-xmas-ep-%E7%AF%AE%E7%90%83%E9%9E%8B/pid-10345106/pgid-10345980", Method.GET);

      response = client.Execute(request);
      content = response.Content;
    }

  }
}
