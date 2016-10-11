using System.Collections.Generic;

namespace VendingMachine.Models
{
    public class Coin
    {
        public static Coin Penny { get; }
        public static Coin Nickel { get; }
        public static Coin Dime { get; }
        public static Coin Quarter { get; }
        public static Coin HalfDollar { get; }
        public static Coin Dollar { get; }
        public static Coin Unknown { get; }

        static Coin ()
        {
            Penny = new Coin(2.5,19.05);
            Nickel = new Coin(5,21.21);
            Dime = new Coin(2.268,17.91);
            Quarter = new Coin(5.67,24.26);
            HalfDollar = new Coin(11.34,30.61);
            Dollar = new Coin(8.1,26.5);
            Unknown = new Coin(0,0);
        }

        public double Weight { get; }
        public double Height { get; }

        private Coin(double weight, double height)
        {
            Weight = weight;
            Height = height;
        }
    }
}
