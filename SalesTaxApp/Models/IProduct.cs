namespace SalesTaxApp.Models
{
    public interface IProduct
    {
        string Name { get; }
        decimal GetPriceWithTax();
        decimal GetBasePrice();
    }
}
