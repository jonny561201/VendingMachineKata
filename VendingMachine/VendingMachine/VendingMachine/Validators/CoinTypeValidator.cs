using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Models;

namespace VendingMachine.VendingMachine.Validators
{
    public static class CoinTypeValidator
    {
        public static Coin Identify(double weight, double diameter)
        {
            var coin = Coin.AllCoins.SingleOrDefault(x => (Math.Abs(x.Height - diameter) < .001 || Math.Abs(x.Weight - weight) < .01));

            return coin ?? Coin.Unknown;
        }
    }
}
