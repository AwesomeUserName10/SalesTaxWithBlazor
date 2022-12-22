using SalesTaxApp.Extensions;
using SalesTaxApp.Models;

namespace SalesTaxApp.Services
{
    public class ShoppingTripCalculator : IShoppingTripCalculator
    {
        public ShoppingTrip BuildShoppingTrip(IEnumerable<IProduct> products)
        {
            decimal totalPrice = products.Sum(p => p.GetPriceWithTax());
            decimal totaltaxes = totalPrice - products.Sum(p => p.GetBasePrice());
            return new ShoppingTrip
            {
                TotalAmount = totalPrice,
                TotalTaxesAmount = totaltaxes,
                Products = products
            };
        }
    }
}
