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
        public void IndentifyShouldReturnPenny()
        {
            _diameter = 19.05;
            _weight = 2.5;

            var actual = CoinTypeValidator.Identify(_weight, _diameter);

            Assert.AreEqual(Coin.Penny, actual);
            Assert.AreEqual(_diameter, actual.Height);
            Assert.AreEqual(_weight, actual.Weight);
        }

        [Test]
        public void IndentifyShouldDetermineNickel()
        {
            _diameter = 21.21;
            _weight = 5;

            var actual = CoinTypeValidator.Identify(_weight, _diameter);

            Assert.AreEqual(Coin.Nickel, actual);
            Assert.AreEqual(_diameter, actual.Height);
            Assert.AreEqual(_weight, actual.Weight);
        }

        [Test]
        public void IdentifyShouldDetermineDime()
        {
            _diameter = 17.91;
            _weight = 2.268;

            var actual = CoinTypeValidator.Identify(_weight, _diameter);

            Assert.AreEqual(Coin.Dime, actual);
            Assert.AreEqual(_diameter, actual.Height);
            Assert.AreEqual(_weight, actual.Weight);
        }

        [Test]
        public void IndentifyShouldReturnQuarter()
        {
            _diameter = 24.26;
            _weight = 5.67;

            var actual = CoinTypeValidator.Identify(_weight, _diameter);

            Assert.AreEqual(Coin.Quarter, actual);
            Assert.AreEqual(_diameter, actual.Height);
            Assert.AreEqual(_weight, actual.Weight);
        }

        [Test]
        public void IdentifyShouldReturnHalfDollar()
        {
            _diameter = 30.61;
            _weight = 11.34;

            var actual = CoinTypeValidator.Identify(_weight, _diameter);

            Assert.AreEqual(Coin.HalfDollar, actual);
            Assert.AreEqual(_diameter, actual.Height);
            Assert.AreEqual(_weight, actual.Weight);
        }

        [Test]
        public void IdentifyShouldReturnDollar()
        {
            _diameter = 26.5;
            _weight = 8.1;

            var actual = CoinTypeValidator.Identify(_weight, _diameter);

            Assert.AreEqual(Coin.Dollar, actual);
            Assert.AreEqual(_diameter, actual.Height);
            Assert.AreEqual(_weight, actual.Weight);
        }

        [Test]
        public void IdentifyShouldReturnInvalidTypeForAllOtherItems()
        {
            _diameter = 5.64;
            _weight = 7.31;

            var actual = CoinTypeValidator.Identify(_weight, _diameter);

            Assert.AreEqual(Coin.Unknown, actual);
        }

        [Test]
        public void IdentifyShouldRoundTotalsAndStillIdentifyQuarter()
        {
            _diameter = 24.2697;
            _weight = 5.6789;

            var actual = CoinTypeValidator.Identify(_weight, _diameter);

            Assert.AreEqual(Coin.Quarter, actual);
        }
    }
}
