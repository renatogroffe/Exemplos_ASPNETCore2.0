using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExemploInjDependencias.Models;

namespace ExemploInjDependencias.Controllers
{
    public class HomeController : Controller
    {
        private ITesteA _testeA;
        private ITesteB _testeB;

        public HomeController(ITesteA testeA, ITesteB testeB)
        {
            _testeA = testeA;
            _testeB = testeB;
        }

        public IActionResult Index([FromServices]TesteC testeC)
        {
            ViewBag.ObjetoA = _testeA;
            ViewBag.ObjetoB = _testeB;
            ViewBag.ObjetoC = testeC;

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
