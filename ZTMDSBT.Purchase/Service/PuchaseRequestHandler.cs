using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZTMDSBT.Purchase.Service
{
  public class PurchaseHttpHandler : HttpClientHandler
  {
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      request.Headers.Referrer = new Uri("http://store.nike.com/cn/zh_cn/");
      request.Headers.Add("UserAgent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
      request.Headers.Add("Origin", "http://www.nike.com");
//      request.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");
//      request.Headers.Add("Content-Locale", "zh_CN");
//      request.Headers.Add("Authorization", "CPC");
//      request.Headers.Add("DNT", "1");
//      request.Headers.Add("Accept-Encoding", "gzip, deflate");
//      request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.6,en;q=0.4,zh-TW;q=0.2");
      return base.SendAsync(request, cancellationToken);
    }
  }
}