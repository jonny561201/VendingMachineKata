using NUnit.Framework;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Validators;

namespace VendingMachine.VendingMachineTests.ValidatorsTests
{
    [TestFixture]
    public class CoinTypeValidatorTests
    {
        private double _diameter;
        private double _weight;

        [Test]
        public void IdentifyShouldDetermineDime()
        {
            _diameter = 2.268;
            _weight = 17.91;

            var actual = CoinTypeValidator.Identify(_weight, _diameter);

            Assert.AreEqual(CoinTypes.Dime, actual);
        }

        [Test]
        public void IndentifyShouldDetermineNickel()
        {
            _diameter = 21.21;
            _weight = 5;

            var actual = CoinTypeValidator.Identify(_weight, _diameter);

            Assert.AreEqual(CoinTypes.Nickel, actual);
        }

        [Test]
        public void IndentifyShouldDetermineQuarter()
        {
            _diameter = 24.26;
            _weight = 5.67;

            var actual = CoinTypeValidator.Identify(_weight, _diameter);

            Assert.AreEqual(CoinTypes.Quarter, actual);
        }

        [Test]
        public void IdentifyShouldReturnInvalidTypeForAllOtherItems()
        {
            _diameter = 5.64;
            _weight = 7.31;

            var actual = CoinTypeValidator.Identify(_weight, _diameter);

            Assert.AreEqual(CoinTypes.Unknown, actual);
        }

        [Test]
        public void IdentifyShouldRoundTotalsAndStillIdentifyQuarter()
        {
            _diameter = 24.2697;
            _weight = 5.6789;

            var actual = CoinTypeValidator.Identify(_weight, _diameter);

            Assert.AreEqual(CoinTypes.Quarter, actual);
        }
    }
}
