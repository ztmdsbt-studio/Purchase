using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ZTMDSBT.Purchase.Service
{
  public class CookiesManager
  {
    private static readonly Lazy<CookiesManager> _current = new Lazy<CookiesManager>();
    private Dictionary<string, CookieContainer> _containers;

    private CookiesManager()
    {
      _containers = new Dictionary<string, CookieContainer>();
    }

    public static CookiesManager Current => _current.Value;

    public CookieContainer this[string userId]
    {
      get { throw new NotImplementedException(); }
      set { throw new NotImplementedException(); }
    }
  }
}
