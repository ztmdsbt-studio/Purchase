using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
      message.Headers.Add("UserAgent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
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
      request.Headers.Add("UserAgent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
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
      request.Headers.Add("UserAgent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
      return request;
    }
    public static HttpRequestMessage BuildCartInfoRequest()
    {
      var request = new HttpRequestMessage(HttpMethod.Get, "ap/services/jcartService?callback=jQuery17206263505546376109_1453400955311&action=getCartSummary&rt=json&country=CN&lang_locale=zh_CN&_=1453401043711");
      request.Headers.Add("Accept", "*/*");
      request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
      request.Headers.Add("Accept-Language", "en-US,en;q=0.8,zh-CN;q=0.6,zh;q=0.4");
      request.Headers.Add("Cache-Control", "no-cache");
      request.Headers.Add("Connection", "keep-alive");
      request.Headers.Add("Host", "secure-store.nike.com");
      request.Headers.Add("Pragma", "no-cache");
      request.Headers.Referrer = new Uri("http://store.nike.com/cn/zh_cn/pd/kobe-11-elite-low-bhm-%E7%AF%AE%E7%90%83%E9%9E%8B/pid-10873886/pgid-11181193");
      request.Headers.Add("UserAgent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
      return request;
    }
  }
}
