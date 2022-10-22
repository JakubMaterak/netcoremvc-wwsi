using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence
{
    public class BooksRepository
    {
        readonly List<Book> _database;

        public BooksRepository()
        {
            _database = new()
            {
                new Book("Stary człowiek i morze", "Ernest Hemingway", 1986, "AAAA", 10, 19.99m),
                new Book("Komu bije dzwon", "Ernest Hemingway", 1997, "BBBB", 0, 119.99m),
                new Book("Alicja w krainie czarów", "C.K. Lewis", 1998, "CCCC", 53, 39.99m),
                new Book("Opowieści z Narnii", "C.K. Lewis", 1999, "DDDD", 33, 49.99m),
                new Book("Harry Potter", "J.K. Rowling", 2000, "EEEE", 23, 69.99m),
                new Book("Paragraf 22", "Joseph Heller", 2001, "FFFF", 5, 45.99m),
                new Book("Lalka", "Bolesław Prus", 2002, "GGGG", 7, 76.99m),
                new Book("To", "Stephen King", 2003, "HHHH", 2, 12.99m),
                new Book("Idiota", "Fiodor Dostojewski", 1950, "IIII", 89, 25.99m),
                new Book("Mistrz i Małgorzata", "Michaił Bułhakow", 1965, "JJJJ", 41, 36.99m),
            };
        }

        public void Insert(Book book)
        {
            _database.Add(book);
        }

        public List<Book> GetAll()
        {
            return _database;
        }

        public void RemoveByTitle(string title)
        {
            var book = GetBookByTitle(title);
            _database.Remove(book);
        }

        public void ChangeState(string title, int stateChange)
        {
            var book = GetBookByTitle(title);
            // Zabezpieczenie by `ProductsAvailable` nie zostało ustawione na wartość negatywną.
            book.ProductsAvailable = Math.Max(book.ProductsAvailable + stateChange, 0);
            _database.First(book => book.Title == title).ProductsAvailable = stateChange;
        }

        protected Book GetBookByTitle(string title)
        {
            try
            {
                return _database.First(book => book.Title == title);
            } catch (InvalidOperationException)
            {
                throw new KeyNotFoundException("Book by the given title could not be found");
            }
        }
    }
}
