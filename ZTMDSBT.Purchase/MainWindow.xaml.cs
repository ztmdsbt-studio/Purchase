using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using ZTMDSBT.Purchase.Selenium;

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
      Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {

    }

    private void button_Click(object sender, RoutedEventArgs e)
    {
      //      FirefoxProfile fp = new FirefoxProfile();
      //      fp.SetPreference("webdriver.load.strategy", "unstable");
      //      fp.SetPreference("browser.startup.homepage", "about:blank");
      //      fp.SetPreference("startup.homepage_welcome_url", "about:blank");
      //      fp.SetPreference("startup.homepage_welcome_url.additional", "about:blank");
      //      fp.SetPreference("browser.cache.disk.enable", "true");
      //      fp.SetPreference("browser.cache.memory.enable", "true");
      //      fp.SetPreference("browser.cache.offline.enable", "true");
      //      fp.SetPreference("network.http.use-cache", "true");
      var chrome = ChromeDriverService.CreateDefaultService();
      chrome.HideCommandPromptWindow = true;
      var driver = new InternetExplorerDriver() { Url = "http://www.nike.com/cn/zh_cn/" };
      var steps = new SeleniumSteps(driver);
      var product = PurchaseConfiguration.GetProduct(((ComboBoxItem)skuCmb.SelectedItem).Content.ToString());

      var user = PurchaseConfiguration.GetUser();
      Task.Run(() => steps.Login(user))
        .ContinueWith(s => steps.GotoProductPage(product.URL))
        .ContinueWith(s => steps.WaitUntilZero())
        .ContinueWith(s => steps.SelectSizeAndQuantity(product))
        .ContinueWith(s => steps.AddedToCart())
        .ContinueWith(s => steps.CreateOrder())
        ;
      //      setps.CreateOrder();
      //      setps.FillPaymentGetwayAndOtherInfo();
    }
  }
}
