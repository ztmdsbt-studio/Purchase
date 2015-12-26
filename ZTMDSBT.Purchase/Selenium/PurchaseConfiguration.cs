using System.IO;
using ZTMDSBT.Purchase.Models;
using json = Newtonsoft.Json;

namespace ZTMDSBT.Purchase.Selenium
{
  internal static class PurchaseConfiguration
  {
    internal static Product GetProduct(string gender)
    {
      var productFileName = gender == "男" ? "product1.json" : "product2.json";
      return json.JsonConvert.DeserializeObject<Product>(File.ReadAllText("./fixtures/" + productFileName));
    }

    internal static User GetUser()
    {
      return json.JsonConvert.DeserializeObject<User>(File.ReadAllText("./fixtures/user.json"));
    }
  }
}
