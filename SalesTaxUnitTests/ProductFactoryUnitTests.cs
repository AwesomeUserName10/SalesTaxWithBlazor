using SalesTaxApp.Builder;
using SalesTaxApp.Models;
using SalesTaxApp.Services;
using static SalesTaxApp.Db.ShopStoreDB;

namespace SalesTaxUnitTests
{
    public class ProductFactoryUnitTests
    {
        private readonly IProductFactory _productFactory;
        public ProductFactoryUnitTests()
        {
            _productFactory = new ProductFactory(new PriceCalculatorService());
        }


        [Theory]
        [InlineData(ProductType.Food, "Burger")]
        [InlineData(ProductType.Books, "Harry Potter")]
        [InlineData(ProductType.Meds, "Strepsils")]
        public void WhenTypeFoodOrBooksOrMedsReceivedThenProductObjectIsCreated(ProductType type, string name)
        {
            //Arrange
            var storeProduct = new StoreProduct(1, name, 1.20m, false, type);

            //Act
            var product = _productFactory.CreateProduct(storeProduct);

            //Assert
            Assert.IsType<Product>(product);
        }

        [Theory]
        [InlineData(ProductType.Other, "Perfume")]
        [InlineData(ProductType.Other, "Coffee")]
        public void WhenTypeOtherReceivedThenSalesTaxProductIsCreated(ProductType type, string name)
        {
            //Arrange
            var storeProduct = new StoreProduct(1, name, 1.20m, false, type);

            //Act
            var product = _productFactory.CreateProduct(storeProduct);

            //Assert
            Assert.IsType<SalesTaxProduct>(product);
        }

        [Theory]
        [InlineData(ProductType.None, "Unknown")]
        public void WhenTypeNotImplementedThenExceptionIsThrown(ProductType type, string name)
        {
            //Arrange
            var storeProduct = new StoreProduct(1, name, 1.20m, false, type);

            //Act & Assert
            Assert.Throws<NotImplementedException>(() => _productFactory.CreateProduct(storeProduct));

        }



        [Theory]
        [InlineData(ProductType.Other, "Perfume")]
        [InlineData(ProductType.Meds, "Strepsils")]
        public void WhenIsImportedIsTrueThenImportedTaxProductIsCreated(ProductType type, string name)
        {
            //Arrange
            var storeProduct = new StoreProduct(1, name, 1.20m, true, type);

            //Act
            var product = _productFactory.CreateProduct(storeProduct);

            //Assert
            Assert.IsType<ImportedTaxProduct>(product);
        }


    }
}
