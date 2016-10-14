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
        public List<Coin> AddAvailableFunds(List<Coin> coins)
        {
            throw new System.NotImplementedException();
        }

        public List<Coin> FindAvailableFunds()
        {
            throw new System.NotImplementedException();
        }
    }
}