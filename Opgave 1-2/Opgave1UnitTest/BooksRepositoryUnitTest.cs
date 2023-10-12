using Opgave1;

namespace Opgave1UnitTest
{
    [TestClass]
    public class BooksRepositoryUnitTest
    {
        private static BooksRepository? booksRepository;
        [TestInitialize]
        public void Init()
        {
            booksRepository = new BooksRepository();
        }

        [TestMethod]
        public void GetByIdTest()
        {
            Book test = booksRepository.GetById(1);
            Assert.AreEqual(test.Price, 80);
            Assert.IsNull(booksRepository.GetById(0));
        }

        [TestMethod]
        public void AddTest()
        {
            Book test = booksRepository.Add(new Book() { Title = "Test", Price = 100 });
            Assert.IsTrue(test.Id > 0);
            Assert.AreEqual(booksRepository.Get().Count(), 6);

            Assert.ThrowsException<ArgumentNullException>(() => booksRepository.Add(new Book() { Title = null, Price = 100 }));
            Assert.ThrowsException<ArgumentException>(() => booksRepository.Add(new Book() { Title = "", Price = 100 }));
            Assert.ThrowsException<ArgumentException>(() => booksRepository.Add(new Book() { Title = "Test", Price = 0 }));
            Assert.ThrowsException<ArgumentException>(() => booksRepository.Add(new Book() { Title = "Test", Price = 1500 }));
        }

        [TestMethod]
        public void DeleteTest()
        {
            booksRepository.Delete(1);
            Assert.AreEqual(booksRepository.Get().Count(), 4);
            Assert.IsNull(booksRepository.GetById(1));
            Assert.IsNull(booksRepository.Delete(0));
        }

    }
}
