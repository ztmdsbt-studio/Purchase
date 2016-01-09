using System;
using System.Net.Http;
using ZTMDSBT.Purchase.Models;

namespace ZTMDSBT.Purchase.Service
{
  public class RequestHandler
  {
//    private static readonly Lazy<RequestHandler> _current = new Lazy<RequestHandler>(() => new RequestHandler());
//    public static RequestHandler Current => _current.Value;
    private HttpClient _client;

    public RequestHandler()
    {
      _client = new HttpClient();
    }
  }
}
