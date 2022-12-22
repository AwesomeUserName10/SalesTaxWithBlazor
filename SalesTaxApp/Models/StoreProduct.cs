using static SalesTaxApp.Db.ShopStoreDB;

namespace SalesTaxApp.Models
{
    public class StoreProduct
    {
        public StoreProduct(int id, string name, decimal price, bool isImported, ProductType productType)
        {
            Name = name;
            Price = price;
            IsImported = isImported;
            ProductType = productType;
            Id = id;
        }

        public int Id { get; }
        public string Name { get; }

        public decimal Price { get; }

        public bool IsImported { get; }

       public ProductType ProductType { get; }

    }
}
