using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    class StubBookRepository : IBookRepository
    {

        public Book[] ResultOfGetAllByIsbn { get; set; }
        public Book[] ResultOfGetAllTitleOfAuthor { get; set; }

        public Book[] GetAllIsbn(string isbn)
        {
            return ResultOfGetAllByIsbn;
        }


        public Book[] GetAllTitleOrAuthor(string titleOrAuthor)
        {
            return ResultOfGetAllTitleOfAuthor;
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
