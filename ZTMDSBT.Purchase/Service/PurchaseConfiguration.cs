using System.IO;
using ZTMDSBT.Purchase.Models;
using json = Newtonsoft.Json;

namespace ZTMDSBT.Purchase.Service
{
  public static class PurchaseConfiguration
  {
    public static Product GetProduct(string gender = "男")
    {
      var productFileName = gender == "男" ? "product1.json" : "product2.json";
      return json.JsonConvert.DeserializeObject<Product>(File.ReadAllText("./fixtures/" + productFileName));
    }

    public static User GetUser()
    {
      return json.JsonConvert.DeserializeObject<User>(File.ReadAllText("./fixtures/user.json"));
    }
  }
}
