//www.nike.com/profile/login?Content-Locale=zh_CN
using System.Linq;
using System.Windows;
using ZTMDSBT.Purchase.Service;

namespace ZTMDSBT.Purchase
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class PhantomPurchase : Window
  {


    public PhantomPurchase()
    {
      InitializeComponent();
      Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    { }

    private void BtnGetProduct_click(object sender, RoutedEventArgs e)
    {
      var product = PurchaseConfiguration.GetProduct();
      product.GetProductInfo(ApplicationContext.Context.LoginedUsers.First().Cookies);
      MessageBox.Show(
        string.Format("Instock:{0}, Outstock:{1}",
          product.ProductSkus.Where(s => s.InStock)
            .Aggregate(string.Empty, (result, next) => result += (next.DisplaySize + ";")),
          product.ProductSkus.Where(s => !s.InStock)
            .Aggregate(string.Empty, (result, next) => result += next.DisplaySize + ";")));
    }

    private async void BtnLogin_click(object sender, RoutedEventArgs e)
    {
      var user = PurchaseConfiguration.GetUser();
      if (await user.LoginByHttpHandler())
      {
        MessageBox.Show("Login succeed!");
      }

      // get user info:
      await user.GetUserInfo();
    }
  }
}