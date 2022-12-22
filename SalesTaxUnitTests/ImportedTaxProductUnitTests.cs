using Moq;
using SalesTaxApp.Models;
using SalesTaxApp.Services;

namespace SalesTaxUnitTests
{
    public class ImportedTaxProductUnitTests
    {
        private readonly IPriceCalculatorService _priceCalculatorService;

        public ImportedTaxProductUnitTests()
        {
            _priceCalculatorService = new PriceCalculatorService();
        }
        [Theory]
        [InlineData("10.00","10.50")]
        [InlineData("11.25", "11.85")]
        public void WhenOnlyImportedTaxProductThen5PercentTaxIsAdded(string price, string expectedPriceWithTax )
        {
            //Arrange
            var baseProduct = new Product("TEST_PRODUCT_NAME", Decimal.Parse(price));
            var importedTaxProduct = new ImportedTaxProduct(baseProduct, _priceCalculatorService);

            //Act
            var actualPriceWithTax = importedTaxProduct.GetPriceWithTax();

            //Assert
            Assert.Equal(Decimal.Parse(expectedPriceWithTax), actualPriceWithTax);

        }

        [Theory]
        [InlineData("10.00", "11.50")]
        [InlineData("11.25", "13.00")]
        public void WhenImportedTaxProductAndSalesTaxProductThen5PercentTaxIsAdded(string price, string expectedPriceWithTax)
        {
            //Arrange
            var baseProduct = new Product("TEST_PRODUCT_NAME", Decimal.Parse(price));
            var salesTaxProduct = new SalesTaxProduct(baseProduct, _priceCalculatorService);
            var importedTaxProduct = new ImportedTaxProduct(salesTaxProduct, _priceCalculatorService);

            //Act
            var actualPriceWithTax = importedTaxProduct.GetPriceWithTax();

            //Assert
            Assert.Equal(Decimal.Parse(expectedPriceWithTax), actualPriceWithTax);

        }
    }
}
