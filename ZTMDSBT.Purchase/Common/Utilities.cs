using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZTMDSBT.Purchase.Common
{
  internal class Utilities
  {
    public static string Base64Encode(string plainText)
    {
      var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
      return System.Convert.ToBase64String(plainTextBytes);
    }

    public static string JsBase64Encode(string plainText)
    {
      return Base64Encode(plainText).Replace("==", "..");
    }

    public static long UnixTimeStamp()
    {
      return (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalMilliseconds;
    }

    public static HttpClient HttpClient(string uriString, CookieContainer cookieContainer = null)
    {
      return new HttpClient(new HttpClientHandler()
      {
        CookieContainer = cookieContainer,
        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
      })
      {
        BaseAddress = new Uri(uriString)
      };
    }
  }
}
