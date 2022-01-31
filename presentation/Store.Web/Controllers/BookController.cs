using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Controllers
{
    public class BookController : Controller
    {

        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookrepositary) 
        {
            this.bookRepository = bookrepositary;
        }
        public IActionResult Index(int id)
        {
            Book book = bookRepository.GetById(id);

            return View(book);
        }
    }
}
