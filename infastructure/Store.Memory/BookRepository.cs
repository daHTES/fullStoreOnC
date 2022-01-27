using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {

        private readonly Book[] books = new[]
        {
            new Book (1, "ISBN 76768-98874", "Роберт Мартин", "Совершенный Код"),
            new Book (2, "ISBN 79068-76654", "Кнут", "Искусство программированния"),
            new Book (3, "ISBN 14768-44334", "Лафоре", "С++ ООП"),
        };

        public Book[] GetAllIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }

        public Book[] GetAllTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query)
                                    || book.Title.Contains(query))
                                       .ToArray();
        }
    }
}
