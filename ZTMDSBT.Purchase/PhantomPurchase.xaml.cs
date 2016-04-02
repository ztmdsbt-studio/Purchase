//www.nike.com/profile/login?Content-Locale=zh_CN
using System.Linq;
using System.Windows;
using ZTMDSBT.Purchase.Models;
using ZTMDSBT.Purchase.Service;

namespace ZTMDSBT.Purchase
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class PhantomPurchase : Window
  {
    private Product product;


    public PhantomPurchase()
    {
      InitializeComponent();
      Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
    }

    private async void BtnGetProduct_click(object sender, RoutedEventArgs e)
    {
      product = PurchaseConfiguration.GetProduct();
      await product.GetProductInfo();
      MessageBox.Show(
        $"Instock:{product.ProductSkus.Where(s => s.InStock).Aggregate(string.Empty, (result, next) => result += (next.DisplaySize + ";"))}, Outstock:{product.ProductSkus.Where(s => !s.InStock).Aggregate(string.Empty, (result, next) => result += next.DisplaySize + ";")}");
    }

    private async void BtnLogin_click(object sender, RoutedEventArgs e)
    {
      var user = PurchaseConfiguration.GetUser();
      await user.LoginByHttpHandler();
      ApplicationContext.Current.LoginedUsers.Add(user);

      await user.GetUserInfo(); // 必要步骤，否则无法在下一步中生成request cookies

      await user.GetCartInfo(); // 必要步骤，获取购物车摘要的cookie。
      MessageBox.Show("Login succeed!");
    }

    private async void BtnAddToCart_click(object sender, RoutedEventArgs e)
    {
      var user = ApplicationContext.Current.LoginedUsers.FirstOrDefault();
      user.AddtoCart(product);
    }
  }
}