namespace VendingMachine.VendingMachine.Validators
{
    public class MoneyValidator
    {
        public bool IsValidCoin(string coin)
        {
            if (coin == "Nickel" || coin == "Dime")
                return true;
            return false;
        }
    }
}
