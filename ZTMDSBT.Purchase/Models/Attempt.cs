using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTMDSBT.Purchase.Models
{
  public class Attempt
  {
    public Product Traget { get; set; }

    public ProductSku MainProductSku { get; set; }

    public int Quantity { get; set; }

    public List<ProductSku> BackupSkus { get; set; }
  }
}
