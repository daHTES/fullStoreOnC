using System.Collections.Generic;
using System.Linq;

namespace Store.Web.Application
{
    public class BookService
    {
        private readonly IBookRepository bookRepositary;

        public BookService(IBookRepository bookRepo) 
        {
            this.bookRepositary = bookRepo;
        }


        public IReadOnlyCollection<BookModel> GetAllByQuery(string query) 
        {

            var books = Book.IsIsbn(query) ? bookRepositary.GetAllByIsbn(query):
                bookRepositary.GetAllByTitleOrAuthor(query);

            return books.Select(Map).ToArray();
        }

        public BookModel GetById(int id) 
        {

            var book = bookRepositary.GetById(id);
            return Map(book);
        }

        private BookModel Map(Book book)
        {
            return new BookModel
            {
                Id = book.Id,
                Isbn = book.Isbn,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Price = book.Price,
            };
        }
    }
}
