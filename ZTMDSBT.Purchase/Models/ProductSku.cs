namespace ZTMDSBT.Purchase.Models
{
  public class ProductSku
  {
    public Product Product { get; set; }

    public string Id { get; set; }

    public bool InStock { get; set; }

    public string DisplaySize { get; set; }

    public string Sku { get; set; }
  }
}