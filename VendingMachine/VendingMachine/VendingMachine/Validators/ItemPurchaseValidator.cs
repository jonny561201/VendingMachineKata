using VendingMachine.Models;

namespace VendingMachine.VendingMachine.Validators
{
    public static class ItemPurchaseValidator
    {
        public static bool CanPurchase(VendingStock stock, decimal amount)
        {
            return amount >= stock.Cost;
        }
    }
}
