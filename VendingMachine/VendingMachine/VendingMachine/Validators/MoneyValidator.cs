using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.VendingMachine.Validators
{
    public class MoneyValidator
    {
        private static List<Coin> _validCoinList = new List<Coin> { Coin.Nickel, Coin.Dime, Coin.Quarter };

        public bool IsValidCoin(Coin coin)
        {
            return _validCoinList.Contains(coin);
        }
    }
}
