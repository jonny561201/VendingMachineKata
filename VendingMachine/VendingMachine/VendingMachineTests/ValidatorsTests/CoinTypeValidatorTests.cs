using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using VendingMachine.VendingMachine.Validators;

namespace VendingMachine.VendingMachineTests.ValidatorsTests
{
    [TestFixture]
    public class CoinTypeValidatorTests
    {
        private CoinTypeValidator _coinValidator = new CoinTypeValidator();
        private double _diameter;
        private double _weight;

        [Test]
        public void IdentifyShouldDetermineDime()
        {
            _diameter = 2.268;
            _weight = 17.91;

            var actual = _coinValidator.Identify(_weight, _diameter);

            Assert.AreEqual(CoinTypes.Dime, actual);
        }
    }
}
