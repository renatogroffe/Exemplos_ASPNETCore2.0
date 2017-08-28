using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExemploMiddleware2.Models;

namespace ExemploMiddleware2.Controllers
{
    public class HomeController : Controller
    {
        [MiddlewareFilter(typeof(IndisponibilidadePipeline))]
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
