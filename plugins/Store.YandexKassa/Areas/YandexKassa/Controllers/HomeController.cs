using Microsoft.AspNetCore.Mvc;
using System;


namespace Store.YandexKassa.Areas.YandexKassa.Controllers
{
    [Area("YandexKassa")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Callback() 
        {
            return View();
        }
    }

    
}
