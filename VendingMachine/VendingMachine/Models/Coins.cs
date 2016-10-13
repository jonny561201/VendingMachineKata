using System.Collections.Generic;

namespace VendingMachine.Models
{
    public class Coin
    {
        public static List<Coin> AllCoins { get; }
        public static Coin Penny { get; }
        public static Coin Nickel { get; }
        public static Coin Dime { get; }
        public static Coin Quarter { get; }
        public static Coin HalfDollar { get; }
        public static Coin Dollar { get; }
        public static Coin Unknown { get; }

        static Coin ()
        {
            Penny = new Coin(2.5, 19.05, 0.01m, false);
            Nickel = new Coin(5, 21.21, 0.05m, true);
            Dime = new Coin(2.268, 17.91, 0.10m, true);
            Quarter = new Coin(5.67, 24.26, 0.25m, true);
            HalfDollar = new Coin(11.34, 30.61, 0.50m, false);
            Dollar = new Coin(8.1, 26.5, 1.00m, false);
            Unknown = new Coin(0, 0, 0.0m, false);
            AllCoins = new List<Coin> { Penny, Nickel, Dime, Quarter, HalfDollar, Dollar, Unknown};
        }

        public double Weight { get; }
        public double Height { get; }
        public decimal Value { get; }
        public bool IsValidTender { get; }

        private Coin(double weight, double height, decimal value, bool isvalidTender)
        {
            Value = value;
            IsValidTender = isvalidTender;
            Weight = weight;
            Height = height;
        }
    }
}
