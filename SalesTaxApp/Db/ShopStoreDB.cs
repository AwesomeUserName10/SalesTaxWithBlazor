using SalesTaxApp.Models;

namespace SalesTaxApp.Db
{
    public class ShopStoreDB : IShopStoreDB
    {
        private readonly IEnumerable<StoreProduct> _listOdProducts;
        public ShopStoreDB()
        {
            _listOdProducts = new List<StoreProduct>
            {
                new StoreProduct(1,"Book",12.49m,false,ProductType.Books),
                new StoreProduct(2,"Chocolate bar",0.85m,false,ProductType.Food),
                new StoreProduct(3,"Music CD",14.99m,false,ProductType.Other),
                new StoreProduct(4,"Imported box of chocolate",10.00m,true,ProductType.Food),
                new StoreProduct(5,"Imported bottle of perfume 1",47.50m,true,ProductType.Other),
                new StoreProduct(6,"Imported bottle of perfume 2",27.99m,true,ProductType.Other),
                new StoreProduct(7,"Bottle of perfume",18.99m,false,ProductType.Other),
                new StoreProduct(8,"Packet of paracetamol",9.75m,false,ProductType.Meds),
                new StoreProduct(9,"Box of imported chocolates",11.25m,true,ProductType.Food)

            };
        }

        public IEnumerable<StoreProduct> ListOfProducts
        {
            get { return _listOdProducts; }

        }

        public enum ProductType
        {
            None,
            Food,
            Meds,
            Books,
            Other
        }

    }
}
