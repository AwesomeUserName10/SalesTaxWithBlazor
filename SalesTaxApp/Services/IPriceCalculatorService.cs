namespace SalesTaxApp.Services
{
    public interface IPriceCalculatorService
    {
        decimal CalculatePrice(decimal basePriceWithTax, decimal basePrice, decimal taxRate, bool isRounded);
    }
}