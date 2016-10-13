using System;
using System.Collections.Generic;
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

        public List<Coin> MakeChange(decimal cost, decimal insertedAmount)
        {
            throw new NotImplementedException();
        }
    }
}
