using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Models;

namespace VendingMachine.VendingMachine.Validators
{
    public static class CoinTypeValidator
    {
        private static readonly List<Coin> AllCoins = new List<Coin> {Coin.Penny, Coin.Nickel, Coin.Dime, Coin.Quarter, Coin.HalfDollar, Coin.Dollar, Coin.Unknown}; 

        public static Coin Identify(double weight, double diameter)
        {
            var coin = AllCoins.SingleOrDefault(x => (Math.Abs(x.Height - diameter) < .001 || Math.Abs(x.Weight - weight) < .01));

            return coin ?? Coin.Unknown;
        }
    }
}
