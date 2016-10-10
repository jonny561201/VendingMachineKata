using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace VendingMachine.VendingMachine.Validators
{
    public class CoinTypeValidator
    {

        private static List<Coin> _coins = new List<Coin> { new Coin(CoinTypes.Dime, 17.91, 2.268), new Coin(CoinTypes.Nickel, 5, 21.21), new Coin(CoinTypes.Quarter, 5.67, 24.26) };

        public CoinTypes Identify(double weight, double diameter)
        {
            var coinTypes = _coins.FirstOrDefault(x => x.Height == diameter && x.Weight == weight);

            return coinTypes == null ? CoinTypes.Unknown : coinTypes.Type;
        }
    }

    public enum CoinTypes
    {
        Unknown = 0,
        Nickel = 1,
        Dime = 2,
        Quarter =3,
    }



    public class Coin
    {
        public double Weight { get; private set; }
        public double Height { get; private set; }
        public CoinTypes Type { get; private set; }

        public Coin(CoinTypes type, double weight, double height)
        {
            Type = type;
            Weight = weight;
            Height = height;
        }
    }
}
