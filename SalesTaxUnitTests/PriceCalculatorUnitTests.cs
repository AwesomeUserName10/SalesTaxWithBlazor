using SalesTaxApp.Services;

namespace SalesTaxUnitTests
{
    public class PriceCalculatorUnitTests
    {
        private readonly IPriceCalculatorService _priceCalculatorService;

        public PriceCalculatorUnitTests()
        {
            _priceCalculatorService = new PriceCalculatorService();

        }

        [Fact]
        public void WhenIsRoundIsTrueTaxIsRounded()
        {
            //Act
            decimal price = _priceCalculatorService.CalculatePrice(14.99m, 14.99m, 0.10m, true);


            //Assert
            Assert.Equal(16.49m, price);
        }


        [Fact]
        public void WhenIsRoundIsFalseTaxIsNotRounded()
        {
            //Act
            decimal price = _priceCalculatorService.CalculatePrice(14.99m, 14.99m, 0.10m, false);


            //Assert
            Assert.Equal(16.4890m, price);
        }
    }
}
