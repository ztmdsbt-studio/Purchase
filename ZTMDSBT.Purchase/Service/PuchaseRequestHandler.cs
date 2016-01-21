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
      return base.SendAsync(request, cancellationToken);
    }
  }
}