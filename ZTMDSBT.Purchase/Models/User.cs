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
using CsQuery.ExtensionMethods.Internal;
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
    private JObject _cart;


    public User()
    {
      Cookies = string.IsNullOrEmpty(Id) ? new CookieContainer() : CookiesManager.Current[Id];
    }

    public string Id { get; private set; }
    public string NikePlusId { get; private set; }
    public string ExternalUserId { get; private set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public bool IsLogined { get; set; }
    public CookieContainer Cookies { get; }
    public ShoppingCart ShoppingCart { get; set; }
    public string AvatarUrl { get; set; }
    public string ScreenName { get; set; }
    public string DisplayName { get; set; }
    public string CountyDistrict { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string LastName { get; private set; }
    public string PostalCode { get; private set; }
    public string DateofBirth { get; private set; }
    public string Gender { get; private set; }
    public string Country { get; private set; }
    public string Height { get; private set; }
    public string Weight { get; private set; }
    public string DistanceUnit { get; private set; }


    //    public bool Login()
    //    {
    //      var client = new RestClient("https://www.nike.com");
    //      var request = Request.Login(this);
    //      var response = client.Execute(request);
    //      if (response.StatusCode == HttpStatusCode.OK)
    //      {
    //        _content = JObject.Parse(response.Content);
    //        Id = _content["entity"]["id"].ToString();
    //        NikePlusId = _content["entity"]["nikePlusId"].ToString();
    //        ExternalUserId = _content["entity"]["externalUserId"].ToString();
    //        Cookies = response.Cookies;
    //        return true;
    //      }
    //      return false;
    //    }

    public async Task LoginByHttpHandler()
    {
      HttpClient client = Utilities.HttpClient("https://www.nike.com", Cookies);
      var content = new FormUrlEncodedContent(new[]
      {
        new KeyValuePair<string, string>("login", Username),
        new KeyValuePair<string, string>("password", Password),
        new KeyValuePair<string, string>("rememberMe", "false"),
      });

      var option = await client.SendAsync(RequestMessageBuilder.BuildOptionLoginRequest());
      option.EnsureSuccessStatusCode();

      var post = await client.SendAsync(RequestMessageBuilder.BuildPostLoginRequest(content));
      post.EnsureSuccessStatusCode();
      Cookies.ReadCookies(post);
      _content = JObject.Parse(await post.Content.ReadAsStringAsync());
      FillUserId();
    }

    private void FillUserId()
    {
      Id = _content["entity"]["id"].ToString();
      NikePlusId = _content["entity"]["nikePlusId"].ToString();
      ExternalUserId = _content["entity"]["externalUserId"].ToString();
    }

    public async Task GetUserInfo()
    {
      var cookieContainer = new CookieContainer();
      var client = Utilities.HttpClient("https://www.nike.com", cookieContainer);
      var option = await client.SendAsync(RequestMessageBuilder.BuildOptionGetUserInfoRequest(Id));
      option.EnsureSuccessStatusCode();

      client = Utilities.HttpClient("https://www.nike.com", Cookies);
      var info = await client.SendAsync(RequestMessageBuilder.BuildGetUserInfoRequest(Id));
      info.EnsureSuccessStatusCode();
      _userInfoContent = JObject.Parse(await info.Content.ReadAsStringAsync());
      FillUserInfo();
    }

    public async Task GetCartInfo()
    {
      var client = Utilities.HttpClient("https://secure-store.nike.com", Cookies);

      var responseMessage = await client.SendAsync(RequestMessageBuilder.BuildCartInfoRequest(this));
      responseMessage.EnsureSuccessStatusCode();
      Cookies.ReadCookies(responseMessage);
    }

    public void AddtoCart(Product product)
    {
      throw new NotImplementedException();
      // "https://secure-store.nike.com/ap/services/jcartService?callback=nike_Cart_handleJCartResponse&action=addItem&lang_locale=zh_CN&country=CN&catalogId=4&productId=10873886&price=1599&siteId=null&line1=Kobe+XI+Elite+Low+BHM&line2=%E7%94%B7%E5%AD%90%E7%AF%AE%E7%90%83%E9%9E%8B&passcode=null&sizeType=null&skuAndSize=15848073%3A42.5&qty=1&rt=json&view=3&skuId=15848073&displaySize=42.5&_=1453400314000"
    }

    public void NavigateToShoppingCartPage()
    {
      throw new NotImplementedException();
    }

    private JObject ParseCartInfo(string cartResponse)
    {
      var json = cartResponse.SubstringBetween(cartResponse.IndexOf('{'), cartResponse.LastIndexOf('}') + 1);
      return JObject.Parse(json);
    }

    private void FillUserInfo()
    {
      var entity = _userInfoContent["entity"];
      var account = entity["account"];
      var avatar = entity["avatar"];
      Id = account["id"].ToString();
      FirstName = entity["firstName"].ToString();
      LastName = entity["lastName"].ToString();
      DateofBirth = entity["dateOfBirth"].ToString();
      PostalCode = entity["postalCode"].ToString();
      Country = entity["postalCode"].ToString();
      Gender = entity["gender"].ToString();
      Height = entity["height"].ToString();
      Weight = entity["weight"].ToString();
      DistanceUnit = entity["distanceUnit"].ToString();
      City = entity["city"].ToString();
      State = entity["state"].ToString();
      CountyDistrict = entity["countyDistrict"].ToString();
      Email = account["email"].ToString();
      ScreenName = account["screenName"].ToString();
      ExternalUserId = account["externalUserId"].ToString();
      AvatarUrl = string.IsNullOrEmpty(avatar["base"].ToString()) ? string.Empty : avatar["base"].ToString();
    }
  }
}