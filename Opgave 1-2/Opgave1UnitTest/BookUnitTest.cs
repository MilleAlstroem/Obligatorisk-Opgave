using Opgave1;

namespace Opgave1UnitTest
{
    [TestClass]
    public class BookUnitTest
    {
        private readonly Book _book = new() { Id = 1, Title = "Hans og Grete", Price = 100.0 };
        private readonly Book _bookTitleLess3 = new() { Id = 2, Title = "Ib", Price = 20.0 };
        private readonly Book _bookTitleNull = new() { Id = 3, Title = null, Price = 12.0 };
        private readonly Book _bookPrice0 = new() { Id = 4, Title = "Den grimme ælling", Price = 0 };
        private readonly Book _bookPriceAbove1200 = new() { Id = 5, Title = "Milionær 101", Price = 1500.0 };

        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual("Id: 1, Title: Hans og Grete, Price: 100", _book.ToString());
        }

        [TestMethod]
        public void ValidateTitleTest()
        {
            Assert.ThrowsException<ArgumentException>(() => _bookTitleLess3.ValidateTitle());
            Assert.ThrowsException<ArgumentNullException>(() => _bookTitleNull.ValidateTitle());
        }

        [TestMethod]
        public void ValidatePriceTest()
        {
            Assert.ThrowsException<ArgumentException>(() => _bookPrice0.ValidatePrice());
            Assert.ThrowsException<ArgumentException>(() => _bookPriceAbove1200.ValidatePrice());
        }

        [TestMethod]
        public void ValidateTest()
        {
            Assert.ThrowsException<ArgumentException>(() => _bookTitleLess3.Validate());
            Assert.ThrowsException<ArgumentNullException>(() => _bookTitleNull.Validate());
            Assert.ThrowsException<ArgumentException>(() => _bookPrice0.Validate());
            Assert.ThrowsException<ArgumentException>(() => _bookPriceAbove1200.Validate());
        }
    }
}