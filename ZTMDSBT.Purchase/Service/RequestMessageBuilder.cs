using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZTMDSBT.Purchase.Common;
using ZTMDSBT.Purchase.Models;

namespace ZTMDSBT.Purchase.Service
{
  public static class RequestMessageBuilder
  {
    public static HttpRequestMessage BuildPostLoginRequest(FormUrlEncodedContent content)
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
      message.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
      message.Content = content;
      return message;
    }

    public static HttpRequestMessage BuildOptionLoginRequest()
    {
      var request = new HttpRequestMessage(HttpMethod.Options, "profile/login?Content-Locale=zh_CN");
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
      request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
      return request;
    }

    public static HttpRequestMessage BuildOptionGetUserInfoRequest(string userId)
    {
      var request = new HttpRequestMessage(HttpMethod.Options, $"profile/services/users/{userId}");
      request.Headers.Add("Accept", "*/*");
      request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
      request.Headers.Add("Accept-Language", "zh-TW,zh;q=0.8,en-US;q=0.6,en;q=0.4,zh-CN;q=0.2");
      request.Headers.Add("Access-Control-Request-Headers", "accept, authorization, content-locale");
      request.Headers.Add("Access-Control-Request-Method", "GET");
      request.Headers.Add("Cache-Control", "no-cache");
      request.Headers.Add("Connection", "keep-alive");
      request.Headers.Add("Host", "www.nike.com");
      request.Headers.Add("Origin", "http://www.nike.com");
      request.Headers.Add("Pragma", "no-cache");
      request.Headers.Referrer = new Uri("http://www.nike.com/cn/zh_cn/");
      request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
      return request;
    }

    public static HttpRequestMessage BuildGetUserInfoRequest(string userId)
    {
      var request = new HttpRequestMessage(HttpMethod.Get, $"profile/services/users/{userId}");
      request.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");
      request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
      request.Headers.Add("Accept-Language", "zh-TW,zh;q=0.8,en-US;q=0.6,en;q=0.4,zh-CN;q=0.2");
      request.Headers.Add("Authorization", "CPC");
      request.Headers.Add("Cache-Control", "no-cache");
      request.Headers.Add("Connection", "keep-alive");
      request.Headers.Add("Content-Locale", "zh_CN");
      request.Headers.Add("Host", "www.nike.com");
      request.Headers.Add("Origin", "http://www.nike.com");
      request.Headers.Add("Pragma", "no-cache");
      request.Headers.Referrer = new Uri("http://www.nike.com/cn/zh_cn/");
      request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
      return request;
    }

    public static HttpRequestMessage BuildAddProductRequest()
    {
      var request = new HttpRequestMessage(HttpMethod.Get, "ap/services/jcartService?callback=nike_Cart_handleJCartResponse&action=addItem&lang_locale=zh_CN&country=CN&catalogId=4&productId=10873886&price=1599&siteId=null&line1=Kobe+XI+Elite+Low+BHM&line2=%E7%94%B7%E5%AD%90%E7%AF%AE%E7%90%83%E9%9E%8B&passcode=null&sizeType=null&skuAndSize=15848073%3A42.5&qty=1&rt=json&view=3&skuId=15848073&displaySize=42.5&_=1453400314000");
      request.Headers.Add("Accept", "*/*");
      request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
      request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.6,en;q=0.4,zh-TW;q=0.2");
      request.Headers.Add("Cache-Control", "no-cache");
      request.Headers.Add("Connection", "keep-alive");
      request.Headers.Add("Host", "secure-store.nike.com");
      request.Headers.Add("Pragma", "no-cache");
      request.Headers.Referrer = new Uri("http://store.nike.com/cn/zh_cn/pd/kobe-11-elite-low-bhm-%E7%AF%AE%E7%90%83%E9%9E%8B/pid-10873886/pgid-11181193");
      request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
      return request;
    }

    public static HttpRequestMessage BuildCartInfoRequest(User user)
    {
      user.Cookies.Add(new Cookie("pr_data", BuildPrData(user)) { Domain = ".nike.com" });
      user.Cookies.Add(new Cookie("pr_id", "14153657021") { Domain = ".nike.com" });
      var unixTime = Utilities.UnixTimeStamp();
      var request = new HttpRequestMessage(HttpMethod.Get, $"ap/services/jcartService?callback=jQuery172024396281223744154_{unixTime}&action=getCartSummary&rt=json&country=CN&lang_locale=zh_CN&_={unixTime}");
      request.Headers.Add("Accept", "*/*");
      request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
      request.Headers.Add("Accept-Language", "en-US,en;q=0.8,zh-CN;q=0.6,zh;q=0.4");
      request.Headers.Add("Cache-Control", "no-cache");
      request.Headers.Add("Connection", "keep-alive");
      request.Headers.Add("Host", "secure-store.nike.com");
      request.Headers.Add("Pragma", "no-cache");
      request.Headers.Referrer = new Uri("http://store.nike.com/cn/zh_cn/pd/kobe-11-elite-low-bhm-%E7%AF%AE%E7%90%83%E9%9E%8B/pid-10873886/pgid-11181193");
      request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
      return request;
    }

    public static HttpRequestMessage BuildProductInfoRequest(string productUrl)
    {
      var request = new HttpRequestMessage(HttpMethod.Get, productUrl);
      request.Headers.Add("Accept", "application/json, application/xml, text/json, text/x-json, text/javascript, text/xml");
      request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
      return request;
    }

    private static string BuildPrData(User user)
    {
      var isLogin = user.IsLogined ? 1 : 0;
      var displayName = user.DisplayName ?? string.Empty;
      isLogin += 0; // isSwoosh 不知道是干什么的， 一直是否。 代码里： true：2 , false: 0
      var exp = string.Empty; // 貌似是过期时间：this.exp && this.exp instanceof Date ? this.exp.toJSON() : "";
      var avatarUrl = user.AvatarUrl ?? string.Empty;
      var profileId = user.Id ?? string.Empty;
      var screenName = user.ScreenName ?? string.Empty;
      return Utilities.JsBase64Encode($"{isLogin}$${displayName}$${avatarUrl}$${exp}$${profileId}$${screenName}$$");
    }
  }
}
// 1$$pangjie0001$$$$$$14153657021$$pangjie0001$$


//Cookie:s_pers=%20c5%3Dnikecom%253Ehomepage%7C1454000836188%3B%20c6%3Dhomepage%7C1454000836190%3B%20c58%3Dno%2520value%7C1454000836194%3B%20l2%3Dno%2520value%7C1454000836196%3B; AnalysisUserId=VqpDvgoMQs8AAHmEw4YAAAFT; slCheck=3s9bAor50TAqHHj7jEMYTrxC/zpcwVOSc0acvOLkdOBG8b32EWOsUGRmzxJxnxDbJLhnXZmcDCqo0oRI2BLAVQ==; sls=3; llCheck=Nbt0ruucQGYFWYOSybvi9nlym8JXst41TuEBPx4rtKOxRzRp777lz/9lAGij1TELHVFwjCnExn6J/2k+l/EbwjJ+DdlS1QYOOQidAUphtZHFcRCkweqx493Kdap2Ss4f; pr_data=MSQkcGFuZ2ppZTAwMDEkJCQkJCQxNDE1MzY1NzAyMSQkcGFuZ2ppZTAwMDEkJA..; pr_id=14153657021
