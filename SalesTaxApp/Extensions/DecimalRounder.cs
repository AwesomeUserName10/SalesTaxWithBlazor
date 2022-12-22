using System;

namespace SalesTaxApp.Extensions
{
    public static class DecimalRounder
    {
        public static decimal Round(this decimal amount)
        {
            var roundedAmount = Math.Ceiling(amount * 20) / 20;
            return roundedAmount;
        }
    }
}
