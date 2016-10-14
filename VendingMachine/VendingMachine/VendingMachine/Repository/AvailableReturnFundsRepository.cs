using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.Repository
{
    public interface IAvailableReturnFundsRepo
    {
        List<Coin> AddAvailableFunds(List<Coin> coins);
        List<Coin> FindAvailableFunds(); 
    }

    public class AvailableReturnFundsRepository : IAvailableReturnFundsRepo
    {
        private List<Coin> _availableFunds = new List<Coin>(); 

        public List<Coin> AddAvailableFunds(List<Coin> coins)
        {
            _availableFunds.AddRange(coins);
            return _availableFunds;
        }

        public List<Coin> FindAvailableFunds()
        {
            throw new System.NotImplementedException();
        }
    }
}