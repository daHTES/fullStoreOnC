using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public interface IBookRepository
    {
        Book[] GetAllIsbn(string isbn);

        Book[] GetAllTitleOrAuthor(string titleOrAuthor);
    }
}
