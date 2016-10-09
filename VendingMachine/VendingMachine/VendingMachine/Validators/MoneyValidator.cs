using System.Collections.Generic;

namespace VendingMachine.VendingMachine.Validators
{
    public class MoneyValidator
    {
        private List<string> _validCoinList = new List<string> { "Nickel", "Dime", "Quarter" };

        public bool IsValidCoin(string coin)
        {
            return _validCoinList.Contains(coin);
        }
    }
}
