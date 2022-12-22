using SalesTaxApp.Models;

namespace SalesTaxApp.Db
{
    public interface IShopStoreDB
    {
        IEnumerable<StoreProduct> ListOfProducts { get; }
    }
}