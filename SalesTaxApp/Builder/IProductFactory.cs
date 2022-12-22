using SalesTaxApp.Models;

namespace SalesTaxApp.Builder
{
    public interface IProductFactory
    {
        IProduct CreateProduct(StoreProduct product);
    }
}