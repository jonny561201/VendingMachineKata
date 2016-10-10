namespace VendingMachine.Models
{
    public enum CoinTypes
    {
        Unknown = 0,
        Nickel = 1,
        Dime = 2,
        Quarter = 3,
    }



    public class Coin
    {
        public double Weight { get; }
        public double Height { get; }
        public CoinTypes Type { get; }

        public Coin(CoinTypes type, double weight, double height)
        {
            Type = type;
            Weight = weight;
            Height = height;
        }
    }
}
