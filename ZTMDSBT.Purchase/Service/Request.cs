using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using ZTMDSBT.Purchase.Models;

namespace ZTMDSBT.Purchase.Service
{
  public static class Request
  {
    public static RestRequest Login(User user)
    {
      var request = new RestRequest(Consts.LoginUrl, Method.POST);
      request.Parameters.Clear();
      request.AddParameter("login", user.Username);
      request.AddParameter("password", user.Password);
      request.AddParameter("rememberMe", "false");
      AddBaseHeaders(request);
      return request;
    }

    public static RestRequest ProductInfoByUrl(string url)
    {

      var request = new RestRequest(Consts.ProductInfoUrl);
      request.AddParameter("action", "getPage");
      request.AddParameter("path", "getPage");
      request.AddParameter("productId", "getPage");
      request.AddParameter("productGroupId", "getPage");
//      request.AddParameter("catalogId", "4");
      request.AddParameter("cache", "false");
      request.AddParameter("country", "getPage");
      request.AddParameter("lang_locale", "getPage");
      
      AddBaseHeaders(request);

      return request;
    }

    private static void AddBaseHeaders(RestRequest request)
    {
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
    }
  }
}
