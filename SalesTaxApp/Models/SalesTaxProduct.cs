using SalesTaxApp.Extensions;
using SalesTaxApp.Services;

namespace SalesTaxApp.Models
{
    public class SalesTaxProduct : IProduct
    {

        const decimal Base_Tax_Rate = 0.10m;

        public string Name { get { return _baseProduct.Name; } }

        private IProduct _baseProduct { get; set; }

        private readonly IPriceCalculatorService _priceCalculatorService;

        public SalesTaxProduct(IProduct baseProduct, IPriceCalculatorService priceCalculatorService)
        {
            _baseProduct = baseProduct ?? throw new ArgumentNullException(nameof(baseProduct));
            _priceCalculatorService = priceCalculatorService ?? throw new ArgumentNullException(nameof(priceCalculatorService));
        }

        public decimal GetPriceWithTax()
        {
            return _priceCalculatorService.CalculatePrice(_baseProduct.GetPriceWithTax(), _baseProduct.GetBasePrice(), Base_Tax_Rate, true);
        }

        public decimal GetBasePrice()
        {
            return _baseProduct.GetBasePrice();
        }

    }
}
