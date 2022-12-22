namespace SalesTaxApp.Models
{
    public class Product: IProduct
    {
        public string Name { get; private set; }
        protected decimal Price { get; private set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public decimal GetPriceWithTax()
        {
            return Price;
        }

        public decimal GetBasePrice()
        {
            return Price;
        }
    }
}