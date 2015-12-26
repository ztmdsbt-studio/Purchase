using System.Collections.Generic;
using RestSharp;

namespace ZTMDSBT.Purchase.Models
{
  public class User
  {
    public string Username { get; set; }

    public string Password { get; set; }

    public string Name { get; set; }

    public bool IsLogined { get; set; }

    public IList<RestResponseCookie> Cookies { get; set; }

    public ShoppingCart ShoppingCart { get; set; }
  }
}