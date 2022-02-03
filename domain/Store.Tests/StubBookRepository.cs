﻿using System;
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

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            throw new NotImplementedException();
        }

        public Book[] GetAllByIsbn(string isbn)
        {
            return ResultOfGetAllByIsbn;
        }


        public Book[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            return ResultOfGetAllTitleOfAuthor;
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
