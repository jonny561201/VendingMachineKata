using VendingMachine.Models;

namespace VendingMachine.VendingMachine.Validators
{
    public interface IStockPurchaseValidator
    {
        bool CanPurchase(VendingStock stock, decimal amount);
    }

    public class ItemPurchaseValidator : IStockPurchaseValidator
    {
        public bool CanPurchase(VendingStock stock, decimal amount)
        {
            return amount >= stock.Cost;
        }
    }
}
