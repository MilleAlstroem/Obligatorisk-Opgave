namespace Opgave1
{
    public class BooksRepository
    {
        private int _nextId = 1;
        private readonly List<Book> _books = new();

        public BooksRepository()
        {
            _books.Add(new Book() { Id = 1, Title = "Harry Potter II", Price = 80 });
            _books.Add(new Book() { Id = 2, Title = "Lord of the Rings", Price = 120 });
            _books.Add(new Book() { Id = 3, Title = "Cooking 101", Price = 35 });
            _books.Add(new Book() { Id = 4, Title = "The Hunger Games", Price = 200 });
            _books.Add(new Book() { Id = 5, Title = "Fourth wing", Price = 149 });
        }

        public IEnumerable<Book>? Get(int? priceMin = null, int? priceMax = null, string? orderBy = null)
        {
            // Price filtering
            IEnumerable<Book>? result = new List<Book>(_books);
            if (priceMin != null)
            {
                result = result.Where(book => book.Price >= priceMin);
            }
            if (priceMax != null)
            {
                result = result.Where(book => book.Price <= priceMax);
            }

            // Title and price sorting
            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "title":
                        result = result.OrderBy(book => book.Title);
                        break;
                    case "price":
                        result = result.OrderBy(book => book.Price);
                        break;
                    default:
                        throw new ArgumentException("Invalid orderBy value", nameof(orderBy));
                }
            }
            return result;
        }

        public Book? GetById(int id)
        {
            return _books.Find(book => book.Id == id);
        }

        public Book? Add(Book book)
        {
            book.Validate();
            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }

        public Book? Delete(int id)
        {
            Book? book = GetById(id);
            if (book != null)
            {
                _books.Remove(book);
                return book;
            }
            return null;
        }

        public Book? Update(int id, Book values)
        {
            values.Validate();
            Book? book = GetById(id);
            if (book != null)
            {
                book.Title = values.Title;
                book.Price = values.Price;
                return book;
            }
            return null;
        }

    }
}
