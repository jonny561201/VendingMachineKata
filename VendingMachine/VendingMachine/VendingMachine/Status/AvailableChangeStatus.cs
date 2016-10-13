using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Models;

namespace VendingMachine.VendingMachine.Status
{
    public class AvailableChangeStatus
    {
        private decimal _totalChange;
        private static readonly List<Coin> AllCoins = new List<Coin> { Coin.Penny, Coin.Nickel, Coin.Dime, Coin.Quarter, Coin.HalfDollar, Coin.Dollar, Coin.Unknown };

        public decimal DepositChange(decimal amount)
        {
            return _totalChange += amount;
        }

        public List<Coin> MakeChange(decimal cost, decimal insertedAmount)
        {
            var change = insertedAmount - cost;
            var coinsToReturn = new List<Coin>();

            foreach (var coin in AllCoins.OrderByDescending(x => x.Value))
            {
                if (change - coin.Value >= 0 && coin.IsValidTender)
                {
                    change -= coin.Value;
                    coinsToReturn.Add(coin);
                }
            }

            return coinsToReturn;
        }
    }

}