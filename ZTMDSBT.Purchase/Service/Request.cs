using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using CsQuery.ExtensionMethods.Internal;
using RestSharp;
using RestSharp.Extensions;
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
      if (url.IsNullOrEmpty())
      {
        return null;
      }

      var productPath = url.Replace("https://store.nike.com/", "").Replace("http://store.nike.com/", "");//.UrlEncode();
      var request = new RestRequest(productPath);
      return request;

      //      var urlParsing = url.Split('/');
      //      var productName = urlParsing[6];
      //      var productId = urlParsing[7].Split('-')[1];
      //      var productGroupId = urlParsing[8].Split('-')[1];
      //      var request = new RestRequest(Consts.ProductInfoUrl);
      //      request.AddParameter("action", "getPage");
      //      request.AddParameter("path", productPath);
      //      request.AddParameter("productId", productId);
      //      request.AddParameter("productGroupId", productGroupId);
      //      request.AddParameter("catalogId", "4");
      //      request.AddParameter("cache", "false");
      //      request.AddParameter("country", "CN");
      //      request.AddParameter("lang_locale", "zh_CN");
      //      request.AddHeader("User-Agent",
      //        "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
      //      request.AddHeader("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.6,en;q=0.4,zh-TW;q=0.2");
      //      request.AddHeader("connection", "keep-alive");

      //      Cookie: AnalysisUserId = Vna@OwoMQ10AAB3tuhkAAAJf; TBMCookie_3736107480867066708 = 296468001451182384DA4dKjYy7AB7wNlZ9aNrrqQRXSc =; ___utmvm =###########; ___utmva=###aaaa####; ___utmvb=#Z#aaaa    X##O#al#: #t#\r\n
      //    Cookie pair: AnalysisUserId = Vna@OwoMQ10AAB3tuhkAAAJf
      //      Cookie pair: TBMCookie_3736107480867066708 = 296468001451182384DA4dKjYy7AB7wNlZ9aNrrqQRXSc =
      //        Cookie pair: ___utmvm =###########
      //    Cookie pair: ___utmva =###aaaa####
      //    Cookie pair: ___utmvb =#Z#aaaa    X##O#al#: #t#

      //      request.AddCookie("AnalysisUserId", "Vna@OwoMQ10AAB3tuhkAAAJf");
      //      request.AddCookie("TBMCookie_3736107480867066708", "296468001451182384DA4dKjYy7AB7wNlZ9aNrrqQRXSc =");
      //      request.AddCookie("___utmv", "##########");
      //      request.AddCookie("___utmva", "###aaaa###");
      //      request.AddCookie("___utmv", "=#Z#aaaa    X##O#al#: #t#");
      //      request.AddCookie("NIKE_COMMERCE_CCR", "1451211370289");
      //      request.AddCookie("nike_locale", "cn/zh_cn");
      //      request.AddCookie("NIKE_COMMERCE_COUNTRY", "CN");
      //      request.AddCookie("NIKE_COMMERCE_LANG_LOCALE", "zh_CN");
      //      request.AddCookie("neo.swimlane", "22");
      //      request.AddCookie("guidU", "0bbb3fe6-9210-48f2-d735-ff34d00ced8a");
      //      request.AddCookie("dreams_sample", "55");
      //      request.AddCookie("utag_main", "_st:1451213171165$ses_id:1451212176743%3Bexp-session");
      //      request.AddCookie("pr_data", "0");
      //      request.AddCookie(" s_sess", "%20s_cc%3Dtrue%3B%20c51%3Dhorizontal%3B%20s_sq%3D%3B");
      //      request.AddCookie(" s_pers", "%20s_fid%3D29B04782855B5867-0ACFEF6932B72D22%7C1514369771516%3B%20c5%3Dnikecom%253Ehomepage%7C1451213171521%3B%20c6%3Dhomepage%7C1451213171524%3B%20c58%3Dno%2520value%7C1451213171532%3B%20l2%3Dno%2520value%7C1451213171535%3B");
      //      request.AddCookie("RES_TRACKINGID", "183539935905800");
      //      request.AddCookie("ResonanceSegment", "1");
      //      request.AddCookie("RES_SESSIONID", "606585589481436");
      //      request.AddCookie("guidS", "a274fe52-0c4b-4aa9-c13b-3ec0792d3fc3");
      //      request.AddCookie("guidSTimestamp", "1451211373092|1451211373092");
      //      request.AddCookie("_gscu_207448657", "51211373dk6uc153");
      //      request.AddCookie("_gscs_207448657", "51211373mocnqi53|pv:1");
      //      request.AddCookie("_gscbrs_207448657", "1");
      //      request.AddCookie("_jzqa", "1.3046520097346759700.1451211373.1451211373.1451211373.1");
      //      request.AddCookie("_jzqb", "1.1.10.1451211373.1");
      //      request.AddCookie("_jzqc", "1");
      //      request.AddCookie("_jzqckmp", "1");
      //      request.AddCookie("_s_vi", "[CS]v1|2B3FDD3785195D08-60000606A00390AE[CE]");
      //      request.AddCookie("dreams_session", "catching-dreams");
      //      return request;
    }

    private static void AddBaseHeaders(RestRequest request)
    {
      request.AddHeader("Accept", "application/json, text/javascript, */*; q=0.01");
      request.AddHeader("Content-Locale", "zh_CN");
      request.AddHeader("Origin", "http://www.nike.com");
      request.AddHeader("User-Agent",
        "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
      request.AddHeader("Authorization", "CPC");
      request.AddHeader("DNT", "1");
      request.AddHeader("Referer", "http://www.nike.com/cn/zh_cn/");
      request.AddHeader("Accept-Encoding", "gzip, deflate");
      request.AddHeader("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.6,en;q=0.4,zh-TW;q=0.2");
    }
  }
}
