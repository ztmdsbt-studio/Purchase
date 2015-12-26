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
using ZTMDSBT.Purchase.Models;
using ZTMDSBT.Purchase.Selenium;
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
      var request = BuildRequest(user);
      var response = client.Execute(request);
      var content = response.Content;
      cookies = response.Cookies;
      request.AddCookie(cookies[0].Name, cookies[0].Value);
    }

    private static RestRequest BuildRequest(User user)
    {
      var request = new RestRequest(Consts.LoginUrl, Method.POST);
      request.Parameters.Clear();
      request.AddParameter("login", user.Username);
      request.AddParameter("password", user.Password);
      request.AddParameter("rememberMe", "false");
      request.AddHeader("Accept", "application/json, text/javascript, */*; q=0.01");
      request.AddHeader("Content-Locale", "zh_CN");
      request.AddHeader("Origin", Consts.BaseUrl);
      request.AddHeader("User-Agent",
        "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
      request.AddHeader("Authorization", "CPC");
      request.AddHeader("DNT", "1");
      request.AddHeader("Referer", Consts.BaseUrl);
      request.AddHeader("Accept-Encoding", "gzip, deflate");
      request.AddHeader("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.6,en;q=0.4,zh-TW;q=0.2");
      return request;
    }
  }
}
