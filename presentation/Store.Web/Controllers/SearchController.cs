using Microsoft.AspNetCore.Mvc;
using Store.Web.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {

        private readonly BookService bookService;


        public SearchController(BookService bookservice) 
        {
            this.bookService = bookservice;
        }

        public IActionResult Index(string query)
        {
            var books = bookService.GetAllByQuery(query);
            return View("Index", books);
        }
    }
}
