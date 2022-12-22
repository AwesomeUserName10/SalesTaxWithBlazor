namespace SalesTaxApp.Models
{
    public class ShoppingTrip
    {
        public IEnumerable<IProduct> Products { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TotalTaxesAmount { get; set; }
    }
}
