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


        public Book[] GetAllByQuery(string query) 
        {
            if (Book.IsIsbn(query))
                return bookRepositary.GetAllIsbn(query);

            return bookRepositary.GetAllTitleOrAuthor(query);
        }
    }
}
