namespace Opgave1
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public double Price { get; set; }

        public void ValidateTitle()
        {
            if (Title == null)
            {
                throw new ArgumentNullException(nameof(Title), "Title cannot be null");
            }
            if (Title.Length < 3)
            {
                throw new ArgumentException(nameof(Title), "Title must be at least 3 characters long");
            }
        }

        public void ValidatePrice()
        {
            if (Price <= 0)
            {
                throw new ArgumentException(nameof(Price), "Price must be higher than 0");
            }
            if (Price > 1200)
            {
                throw new ArgumentException(nameof(Price), "Price must be 1200 or lower");
            }
        }

        public void Validate()
        {
            ValidateTitle();
            ValidatePrice();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Price: {Price}";
        }
    }
}