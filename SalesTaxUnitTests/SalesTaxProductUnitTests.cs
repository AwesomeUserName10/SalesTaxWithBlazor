using SalesTaxApp.Models;
using SalesTaxApp.Services;

namespace SalesTaxUnitTests
{
    public class SalesTaxProductUnitTests
    {
        private readonly IPriceCalculatorService _priceCalculatorService;
        public SalesTaxProductUnitTests()
        {
            _priceCalculatorService = new PriceCalculatorService();

        }

        [Theory]
        [InlineData("18.99", "20.89")]
        [InlineData("10.00", "11.00")]
        public void WhenSalesTaxProductThen10PercentTaxIsAdded(string price, string expectedPriceWithTax)
        {
            //Arrange
            var baseProduct = new Product("TEST_PRODUCT_NAME", Decimal.Parse(price));
            var salesTaxProduct = new SalesTaxProduct(baseProduct, _priceCalculatorService);

            //Act
            var actualPriceWithTax = salesTaxProduct.GetPriceWithTax();

            //Assert
            Assert.Equal(Decimal.Parse(expectedPriceWithTax),actualPriceWithTax);

        }

       
    }
}