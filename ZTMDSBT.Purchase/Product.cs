using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ZTMDSBT.Purchase
{
  public class Product
  {
    public string SKU { get; set; }

    public string Size { get; set; }

    public int Quantity { get; set; }

    public string URL { get; set; }
  }
}
