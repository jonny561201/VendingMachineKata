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

        public CoinTypes Identify(double weight, double diameter)
        {
            throw new NotImplementedException();
        }
    }

    public enum CoinTypes
    {
        Penny = 0,
        Nickel = 1,
        Dime = 2,
        Quarter =3
    }
}
