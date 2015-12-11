using System.Threading.Tasks;
using System.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ZTMDSBT.Purchase
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void button_Click(object sender, RoutedEventArgs e)
    {
      IWebDriver driver = new FirefoxDriver() { Url = "http://www.nike.com/cn/zh_cn/" };
      var steps = new SeleniumSteps(driver);
      var product = PurchaseConfiguration.GetProduct();
      var user = PurchaseConfiguration.GetUser();
      Task.Run(() => steps.Login(user))
        .ContinueWith(s => steps.GotoProductPage(product.URL))
        .ContinueWith(s => steps.SelectSizeAndQuantity());
      //      setps.AddedToCart();
      //      setps.CreateOrder();
      //      setps.FillPaymentGetwayAndOtherInfo();
    }
  }
}
