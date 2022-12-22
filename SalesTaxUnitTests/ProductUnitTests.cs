using SalesTaxApp.Models;

namespace SalesTaxUnitTests
{
    public class ProductUnitTests
    {
        [Fact]
        public void WhenProductThenNoTaxIsAdded()
        {
            //Arrange
            var price = 15.43m;
            var product = new Product("TEST_PRODUCT_NAME", price);

            //Act
            var actualPriceWithTax = product.GetPriceWithTax();

            //Assert
            Assert.Equal(price, actualPriceWithTax);

        }
    }
}
