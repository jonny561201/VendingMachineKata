using VendingMachine.Models;

namespace VendingMachine.VendingMachine.Status
{
    public class AvailableChangeStatus
    {
        private decimal _totalChange;

        public decimal DepositChange(decimal amount)
        {
            return _totalChange += amount;
        }

        public decimal MakeChange(decimal cost, decimal insertedAmount)
        {
            return insertedAmount - cost;
        }
    }
}
