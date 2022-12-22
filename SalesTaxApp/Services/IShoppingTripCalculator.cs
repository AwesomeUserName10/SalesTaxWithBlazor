using SalesTaxApp.Models;

namespace SalesTaxApp.Services
{
    public interface IShoppingTripCalculator
    {
        ShoppingTrip BuildShoppingTrip(IEnumerable<IProduct> products);
    }
}