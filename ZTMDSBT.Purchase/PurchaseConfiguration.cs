using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using json = Newtonsoft.Json;

namespace ZTMDSBT.Purchase
{
  internal static class PurchaseConfiguration
  {
    internal static Product GetProduct()
    {
      return json.JsonConvert.DeserializeObject<Product>(File.ReadAllText("./fixtures/products.json"));
    }

    internal static User GetUser()
    {
      return json.JsonConvert.DeserializeObject<User>(File.ReadAllText("./fixtures/user.json"));
    }
  }
}
