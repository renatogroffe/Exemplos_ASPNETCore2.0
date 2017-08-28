using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ExemploIMemoryCache.Models;

namespace ExemploIMemoryCache.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(
            [FromServices]IMemoryCache cache)
        {
            DateTime testeCache = cache.GetOrCreate<DateTime>(
                "TesteCache", context =>
                {
                    context.SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
                    context.SetPriority(CacheItemPriority.High);
                    return DateTime.Now;
                });

            ViewBag.TesteCache = testeCache;
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