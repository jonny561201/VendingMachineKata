﻿using System.Collections.Generic;
using System.Linq;
using VendingMachine.Models;
using VendingMachine.Repository;
using VendingMachine.VendingMachineTests.StatusTests;

namespace VendingMachine.VendingMachine.Status
{
    public class AvailableChangeStatus
    {
        private decimal _totalChange;
        private readonly IAvailableReturnFundsRepo _returnRepo;
        private readonly List<Coin> _availableReturnFund = new List<Coin>();

        public AvailableChangeStatus(IAvailableReturnFundsRepo returnRepo)
        {
            _returnRepo = returnRepo;
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

        public List<Coin> AddChange(List<Coin> coins)
        {
            _availableReturnFund.AddRange(coins);
            return _availableReturnFund;
        }
    }

}