using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CsQuery.ExtensionMethods.Internal;

namespace ZTMDSBT.Purchase.Common
{
  public static class Extendtions
  {
    public static List<Cookie> List(this CookieContainer container)
    {
      var cookies = new List<Cookie>();
      var table = (Hashtable)container.GetType().InvokeMember("m_domainTable",
        BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance,
        null,
        container,
        new object[] { });
      foreach (var key in table.Keys)
      {
        Uri uri = null;
        var domain = key as string;
        if (domain == null)
          continue;
        if (domain.StartsWith("."))
          domain = domain.Substring(1);
        var address = $"http://{domain}/";
        if (Uri.TryCreate(address, UriKind.RelativeOrAbsolute, out uri) == false)
          continue;
        cookies.AddRange(container.GetCookies(uri).Cast<Cookie>());
      }
      return cookies;
    }

    public static Cookie GetCookieByName(this CookieContainer container, string name)
    {
      return container.List().FirstOrDefault(c => c.Name == name);
    }

    public static void ReadCookies(this CookieContainer cookieContainer, HttpResponseMessage response)
    {
      var pageUri = response.RequestMessage.RequestUri;
      IEnumerable<string> cookies;
      if (!response.Headers.TryGetValues("set-cookie", out cookies))
        return;

      foreach (var c in cookies)
      {
        cookieContainer.SetCookies(pageUri, c.Replace("secure", ""));
      }
    }

    public static Cookie ToCookie(this string str)
    {
      if (string.IsNullOrWhiteSpace(str))
        return null;
      var elements = str.SplitClean(';').ToArray();
      var keyValues = new NameValueCollection();
      var cookie = new Cookie();
      var nameValue = elements[0].SplitClean('=').ToArray();
      cookie.Name = nameValue[0];
      cookie.Value = nameValue[1];
      foreach (var element in elements.Skip(1))
      {
        if (element.Contains('='))
        {
          var keyValue = element.Split('=');
          keyValues.Add(keyValue[0].ToLower(), keyValue[1]);
        }
        //        else if (element.ToLower() == "secure")
        //        {
        //          cookie.Secure = true;
        //        }
        //        else if (element.ToLower() == "httponly")
        //        {
        //          cookie.HttpOnly = true;
        //        }
      }

      cookie.Domain = keyValues["domain"];
      cookie.Path = keyValues["path"];
      return cookie;
    }
  }
}
