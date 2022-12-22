using SalesTaxApp.Models;
using SalesTaxApp.Services;

namespace SalesTaxUnitTests
{
    public class ShoppingTripCalculatorUnitTests
    {
        private readonly IShoppingTripCalculator _shoppingTripCalculator;
        private readonly IPriceCalculatorService _priceCalculatorService;

        public ShoppingTripCalculatorUnitTests()
        {
            _shoppingTripCalculator = new ShoppingTripCalculator();
            _priceCalculatorService = new PriceCalculatorService();
        }

        [Fact]
        public void WhenCallingBuildShoppingTripWithFirstCaseProductsTheCorrectAmountsShouldBeCalculated()
        {
            //Arrange
            var listOfProducts = new List<IProduct>
            {
                new Product("Book",12.49m),
                new Product("Chocolate bar", 0.85m),
                new SalesTaxProduct(new Product("Music CD", 14.99m),_priceCalculatorService)
            };
            
            //Act
            var shoppingTrip = _shoppingTripCalculator.BuildShoppingTrip(listOfProducts);

            //Assert
            Assert.Equal(1.50m, shoppingTrip.TotalTaxesAmount);
            Assert.Equal(29.83m, shoppingTrip.TotalAmount);

        }

        [Fact]
        public void WhenCallingBuildShoppingTripWithSecondCaseProductsTheCorrectAmountsShouldBeCalculated()
        {
            //Arrange
            var listOfProducts = new List<IProduct>
            {
                new ImportedTaxProduct(new Product("Imported box of chocolates", 10.00m),_priceCalculatorService),
                new ImportedTaxProduct(new SalesTaxProduct(new Product("Imported bottle of perfume", 47.50m),_priceCalculatorService),_priceCalculatorService),
            };

            //Act
            var shoppingTrip = _shoppingTripCalculator.BuildShoppingTrip(listOfProducts);

            //Assert
            Assert.Equal(7.65m, shoppingTrip.TotalTaxesAmount);
            Assert.Equal(65.15m, shoppingTrip.TotalAmount);

        }

        [Fact]
        public void WhenCallingBuildShoppingTripWithThirdCaseProductsTheCorrectAmountsShouldBeCalculated()
        {
            //Arrange
            var listOfProducts = new List<IProduct>
            {
                new ImportedTaxProduct(new SalesTaxProduct(new Product("Imported bottle of perfume", 27.99m),_priceCalculatorService),_priceCalculatorService),
                new SalesTaxProduct(new Product("Bottle of perfume", 18.99m),_priceCalculatorService),
                new Product("Packet of paracetamol", 9.75m),
                new ImportedTaxProduct(new Product("Box of imported chocolates", 11.25m),_priceCalculatorService),
            };

            //Act
            var shoppingTrip = _shoppingTripCalculator.BuildShoppingTrip(listOfProducts);

            //Assert
            Assert.Equal(6.70m, shoppingTrip.TotalTaxesAmount);
            Assert.Equal(74.68m, shoppingTrip.TotalAmount);

        }
    }
}
