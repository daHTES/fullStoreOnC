using Store.Web.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
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

            var books = Book.IsIsbn(query) ? bookRepositary.GetAllIsbn(query):
                bookRepositary.GetAllTitleOrAuthor(query);

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
                Id = book.ID,
                Isbn = book.Isbn,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Price = book.Price,
            };
        }
    }
}
