using System.Collections.Generic;
using System.Linq;
using VendingMachine.Models;
using VendingMachine.Repository;

namespace VendingMachine.VendingMachine.Status
{
    public class AvailableChangeStatus
    {
        private decimal _totalChange;
        private readonly IAvailableReturnFundsRepo _returnFundsRepo;

        public AvailableChangeStatus(IAvailableReturnFundsRepo returnFundsRepo)
        {
            _returnFundsRepo = returnFundsRepo;
        }

        public decimal DepositChange(decimal amount)
        {
            return _totalChange += amount;
        }

        public static IEnumerable<Coin> MakeChange(decimal cost, decimal insertedAmount)
        {
            var change = insertedAmount - cost;
            var coinsToReturn = new List<Coin>();

            foreach (var coin in Coin.AllCoins.OrderByDescending(x => x.Value))
            {
                if (change - coin.Value >= 0 && coin.IsValidTender)
                {
                    while (change >= coin.Value)
                    {
                        change -= coin.Value;
                        coinsToReturn.Add(coin);
                    }
                }
            }
            return coinsToReturn;
        }

        public IEnumerable<Coin> AddChange(List<Coin> coins)
        {
            return _returnFundsRepo.AddAvailableFunds(coins);
        }
    }

}