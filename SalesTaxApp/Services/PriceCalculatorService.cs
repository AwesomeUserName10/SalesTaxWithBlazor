using SalesTaxApp.Extensions;

namespace SalesTaxApp.Services
{
    public class PriceCalculatorService: IPriceCalculatorService
    {
        public decimal CalculatePrice(decimal basePriceWithTax, decimal basePrice, decimal taxRate, bool isRounded)
        {
            
            return basePriceWithTax + (isRounded ? (basePrice * taxRate).Round() : (basePrice * taxRate));
        }
    }
}
