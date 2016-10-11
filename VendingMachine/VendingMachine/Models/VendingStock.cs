    namespace VendingMachine.Models
{
    public class VendingStock
    {
        public static VendingStock Pop { get; }
        public static VendingStock Chips { get; }
        public static VendingStock Candy { get; }

        static VendingStock()
        {
            Chips = new VendingStock(0.50m);
            Candy = new VendingStock(0.65m);
            Pop = new VendingStock(1.00m);
        }

        public decimal Cost;

        private VendingStock(decimal cost)
        {
            Cost = cost;
        }
    }
}
