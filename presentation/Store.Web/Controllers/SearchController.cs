using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IBookRepository bookrepositary;

        public SearchController(IBookRepository bookRepo) 
        {
            this.bookrepositary = bookRepo;
        }

        public IActionResult Index(string query)
        {
            var books = bookrepositary.GetAllTitle(query);
            return View(books);
        }
    }
}
