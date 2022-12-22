using SalesTaxApp.Models;
using SalesTaxApp.Services;
using static SalesTaxApp.Db.ShopStoreDB;

namespace SalesTaxApp.Builder
{
    public class ProductFactory : IProductFactory
    {
        private readonly IPriceCalculatorService _priceCalculatorService;
        public ProductFactory(IPriceCalculatorService priceCalculatorService)
        {
            _priceCalculatorService =  priceCalculatorService ?? throw new ArgumentNullException(nameof(priceCalculatorService));

        }
        public IProduct CreateProduct(StoreProduct product)
        {
            IProduct newProduct;
            switch (product.ProductType)
            {
                case ProductType.Books:
                case ProductType.Meds:
                case ProductType.Food:
                    newProduct = new Product(product.Name, product.Price);
                    break;
                case ProductType.Other:
                    newProduct = new SalesTaxProduct(new Product(product.Name, product.Price), _priceCalculatorService);
                    break;
                default:
                    throw new NotImplementedException("This type is not supported!");

            }

            if (product.IsImported)
            {
                newProduct = new ImportedTaxProduct(newProduct, _priceCalculatorService);
            }

            return newProduct;
        }
    }
}
