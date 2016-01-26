using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;
using RestSharp;
using ZTMDSBT.Purchase.Common;
using ZTMDSBT.Purchase.Service;

namespace ZTMDSBT.Purchase.Models
{
  public class User
  {
    private JObject _content;

    private JObject _userInfoContent;

    private readonly CookieContainer _cookie;


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

    public async Task<bool> LoginByHttpHandler()
    {
      HttpClient client = HttpClient("https://www.nike.com");
      var content = new FormUrlEncodedContent(new[]
      {
        new KeyValuePair<string, string>("login", Username),
        new KeyValuePair<string, string>("password", Password),
        new KeyValuePair<string, string>("rememberMe", "false"),
      });

      var result = await client.SendAsync(RequestMessageBuilder.BuildOptionLoginRequest())
        .ContinueWith(async option =>
        {
          var post = await client.SendAsync(RequestMessageBuilder.BuildPostLoginRequest(content));
          if (!post.IsSuccessStatusCode)
            return false;

          var contentStr = post.Content.ReadAsStringAsync().Result;
          _cookie.ReadCookies(post);
          _content = JObject.Parse(contentStr);
          Id = _content["entity"]["id"].ToString();
          NikePlusId = _content["entity"]["nikePlusId"].ToString();
          ExternalUserId = _content["entity"]["externalUserId"].ToString();
          return true;
        }).Unwrap();
      return result;
    }

    public async Task GetUserInfo()
    {
      var cookieContainer = new CookieContainer();
      var client = HttpClient("https://www.nike.com", cookieContainer);
      var result = await client
                          .SendAsync(RequestMessageBuilder.BuildOptionGetUserInfoRequest(Id))
                          .ContinueWith(async option =>
                          {
                            var cookies = option.Result.Headers;
                            client = HttpClient("https://www.nike.com");
                            var info = await client.SendAsync(RequestMessageBuilder.BuildGetUserInfoRequest(Id));
                            _userInfoContent = JObject.Parse(info.Content.ReadAsStringAsync().Result);
                            return info;
                          })
                          .Unwrap();
    }

    public void AddtoCart(Product product)
    {
      throw new NotImplementedException();
      // "https://secure-store.nike.com/ap/services/jcartService?callback=nike_Cart_handleJCartResponse&action=addItem&lang_locale=zh_CN&country=CN&catalogId=4&productId=10873886&price=1599&siteId=null&line1=Kobe+XI+Elite+Low+BHM&line2=%E7%94%B7%E5%AD%90%E7%AF%AE%E7%90%83%E9%9E%8B&passcode=null&sizeType=null&skuAndSize=15848073%3A42.5&qty=1&rt=json&view=3&skuId=15848073&displaySize=42.5&_=1453400314000"
    }

    public async void GetCartInfo()
    {
      var client = HttpClient("https://secure-store.nike.com");
      _cookie.Add(new Cookie("pr_data", "MSQk5rSBIOW6niQkJCQkJDE0MTUzNjU3MDIxJCRwYW5namllMDAwMSQk") { Domain = ".nike.com" });
      _cookie.Add(new Cookie("pr_id", "14153657021") { Domain = ".nike.com" });
      _cookie.Add(new Cookie("slsw", "N:w") { Domain = ".nike.com" });
      var cart = await client.SendAsync(RequestMessageBuilder.BuildCartInfoRequest());
    }

    public void NavigateToShoppingCartPage()
    {
      throw new NotImplementedException();
    }

    private HttpClient HttpClient(string uriString, CookieContainer cookieContainer = null)
    {
      return new HttpClient(new HttpClientHandler()
      {
        CookieContainer = cookieContainer ?? _cookie,
        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
      })
      {
        BaseAddress = new Uri(uriString)
      };
    }
  }
}