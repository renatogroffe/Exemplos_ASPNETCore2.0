using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExemploResponseCache.Models;

namespace ExemploResponseCache.Controllers
{
    public class HomeController : Controller
    {
        [ResponseCache(Duration = 30)]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
