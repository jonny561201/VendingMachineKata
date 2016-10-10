using System.Collections.Generic;
using System.Linq;
using VendingMachine.Models;

namespace VendingMachine.VendingMachine.Validators
{
    public class CoinTypeValidator
    {

        private static readonly List<Coin> Coins = new List<Coin> { new Coin(CoinTypes.Dime, 17.91, 2.268), new Coin(CoinTypes.Nickel, 5, 21.21), new Coin(CoinTypes.Quarter, 5.67, 24.26) };

        public static CoinTypes Identify(double weight, double diameter)
        {
            var coinTypes = Coins.FirstOrDefault(x => (x.Height == diameter || x.Weight == weight));

            return coinTypes?.Type ?? CoinTypes.Unknown;
        }
    }
}
