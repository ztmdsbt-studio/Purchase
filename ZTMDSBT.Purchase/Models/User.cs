using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;
using ZTMDSBT.Purchase.Service;

namespace ZTMDSBT.Purchase.Models
{
  public class User
  {
    private JObject _content;

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

    public Task LoginByHttpHandler()
    {
      
    }

    public Task AddtoCart(Product product)
    {
      throw new NotImplementedException();
    }

    public Task NavigateToShoppingCartPage()
    {
      throw new NotImplementedException();
    }
  }
}