namespace VendingMachine.VendingMachine.Validators
{
    public class MoneyValidator
    {
        public bool IsValidCoin(string coin)
        {
            if (coin == "Nickel")
                return true;
            return false;
        }
    }
}
