using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {

        private readonly Book[] books = new[]
        {
            new Book (1, "Исскувство Код"),
            new Book (2, "Чистый Код"),
            new Book (3, "С++ ООП"),
        };
        public Book[] GetAllTitle(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart)).ToArray();
        }
    }
}
