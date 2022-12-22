using SalesTaxApp.Extensions;
using SalesTaxApp.Services;

namespace SalesTaxApp.Models
{
    public class ImportedTaxProduct : IProduct
    {

        const decimal Import_Tax_Rate = 0.05m;
        private IProduct _baseProduct { get; set; }
        public string Name { get { return _baseProduct.Name; } }

        private readonly IPriceCalculatorService _priceCalculatorService;


        public ImportedTaxProduct(IProduct baseProduct, IPriceCalculatorService priceCalculatorService)
        {
            _baseProduct = baseProduct ?? throw new ArgumentNullException(nameof(baseProduct));
            _priceCalculatorService = priceCalculatorService ?? throw new ArgumentNullException(nameof(priceCalculatorService));
        }

        public decimal GetPriceWithTax()
        {
            return _priceCalculatorService.CalculatePrice(_baseProduct.GetPriceWithTax(), _baseProduct.GetBasePrice(), Import_Tax_Rate, true);
        }

        public decimal GetBasePrice()
        {
            return _baseProduct.GetBasePrice();
        }

    }
}
