using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;
using RestSharp;
using ZTMDSBT.Purchase.Service;

namespace ZTMDSBT.Purchase.Models
{
  public class User
  {
    private JObject _content;

    private CookieContainer _cookie;


    public User()
    {
      _cookie = string.IsNullOrEmpty(Id) ? new CookieContainer() : CookiesManager.Current[Id];
    }

    public string Id { get; private set; }

    public string NikePlusId { get; private set; }

    public string ExternalUserId { get; private set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Name { get; set; }

    public bool IsLogined { get; set; }

    public IList<RestResponseCookie> Cookies { get; private set; }

    public ShoppingCart ShoppingCart { get; set; }

    public bool Login()
    {
      var client = new RestClient("https://www.nike.com");
      var request = Request.Login(this);
      var response = client.Execute(request);
      if (response.StatusCode == HttpStatusCode.OK)
      {
        _content = JObject.Parse(response.Content);
        Id = _content["entity"]["id"].ToString();
        NikePlusId = _content["entity"]["nikePlusId"].ToString();
        ExternalUserId = _content["entity"]["externalUserId"].ToString();
        Cookies = response.Cookies;
        return true;
      }
      return false;
    }

    public async Task LoginByHttpHandler()
    {
      var client = new HttpClient(new PurchaseHttpHandler()
      {
        CookieContainer = _cookie,
        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
      })
      {
        BaseAddress = new Uri("https://www.nike.com")
      };
      var content = new FormUrlEncodedContent(new[]
      {
        new KeyValuePair<string, string>("login", Username),
        new KeyValuePair<string, string>("password", Password),
        new KeyValuePair<string, string>("rememberMe", "false"),
      });

      var optionRequest = BuildOptionLoginRequest();
      var option = client.SendAsync(optionRequest).Result;

      var postRequest = BuildPostLoginRequest(content);
      var post = await client.SendAsync(postRequest);

      if (!post.IsSuccessStatusCode) return;
      var contentType = post.Content.Headers.ContentType;
      if (string.IsNullOrEmpty(contentType.CharSet))
      {
        //        contentType.CharSet = "utf-8";
      }
      var contentStr = post.Content.ReadAsStringAsync().Result;

      _content = JObject.Parse(contentStr);
      Id = _content["entity"]["id"].ToString();
      NikePlusId = _content["entity"]["nikePlusId"].ToString();
      ExternalUserId = _content["entity"]["externalUserId"].ToString();
      MessageBox.Show("hahaha!");
      return;
    }

    private async Task<string> getCharSetAsync(HttpContent httpContent)
    {
      var charset = httpContent.Headers.ContentType.CharSet;
      if (!string.IsNullOrEmpty(charset))
        return charset;
      var content = await httpContent.ReadAsStringAsync();
      var match = Regex.Match(content, @"charset=(?<charset>.+?)""", RegexOptions.IgnoreCase);
      if (!match.Success)
        return charset;
      return match.Groups["charset"].Value;
    }

    private static HttpRequestMessage BuildPostLoginRequest(FormUrlEncodedContent content)
    {
      var message = new HttpRequestMessage(HttpMethod.Post, "profile/login?Content-Locale=zh_CN");
      message.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");
      message.Headers.Add("Accept-Encoding", "gzip, deflate");
      message.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.6,en;q=0.4,zh-TW;q=0.2");
      message.Headers.Add("Authorization", "CPC");
      message.Headers.Add("Cache-Control", "no-cache");
      message.Headers.Add("Connection", "keep-alive");
      message.Headers.Add("Content-Locale", "zh_CN");
      message.Headers.Add("DNT", "1");
      message.Headers.Add("Host", "www.nike.com");
      message.Headers.Add("Origin", "http://www.nike.com");
      message.Headers.Add("Pragma", "no-cache");
      message.Headers.Referrer = new Uri("http://store.nike.com/cn/zh_cn/");
      message.Headers.Add("UserAgent",
        "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
      message.Content = content;
      return message;
    }

    private static HttpRequestMessage BuildOptionLoginRequest()
    {
      HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Options, "profile/login?Content-Locale=zh_CN");
      request.Headers.Add("Accept", "*/*");
      request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
      request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.6,en;q=0.4,zh-TW;q=0.2");
      request.Headers.Add("Access-Control-Request-Headers", "accept, authorization, content-locale, content-type");
      request.Headers.Add("Access-Control-Request-Method", "POST");
      request.Headers.Add("Cache-Control", "no-cache");
      request.Headers.Add("Connection", "keep-alive");
      request.Headers.Add("DNT", "1");
      request.Headers.Add("Host", "www.nike.com");
      request.Headers.Add("Origin", "http://www.nike.com");
      request.Headers.Add("Pragma", "no-cache");
      request.Headers.Referrer = new Uri("http://store.nike.com/cn/zh_cn/");
      request.Headers.Add("UserAgent",
        "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
      return request;
    }

    public void AddtoCart(Product product)
    {
      throw new NotImplementedException();
    }

    public void NavigateToShoppingCartPage()
    {
      throw new NotImplementedException();
    }
  }
}