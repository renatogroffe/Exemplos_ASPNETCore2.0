using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using ExemploSqlCache.Models;

namespace ExemploSqlCache.Controllers
{
    public class HomeController : Controller
    {
        private IDistributedCache _cache;

        public HomeController(IDistributedCache cache)
        {
            _cache = cache;
        }

        private void ArmazenarValorCache(
            string chave, string valor)
        {
            DistributedCacheEntryOptions opcoesCache =
                new DistributedCacheEntryOptions();
            opcoesCache.SetAbsoluteExpiration(
                TimeSpan.FromMinutes(1));

            _cache.SetString(chave, valor, opcoesCache);
        }

        public IActionResult Index()
        {
            string testeString =
                _cache.GetString("TesteString");
            if (testeString == null)
            {
                testeString = "Valor de teste";
                ArmazenarValorCache("TesteString", testeString);
            }
            ViewBag.TesteString = testeString;

            TipoComplexo objetoComplexo = null;
            string strObjetoComplexo =
                _cache.GetString("TesteObjetoComplexo");
            if (strObjetoComplexo == null)
            {
                objetoComplexo = new TipoComplexo();
                objetoComplexo.Texto = "Valor de exemplo";
                objetoComplexo.ValorInteiro = 2016;
                objetoComplexo.ValorNumerico = 1914.99;

                strObjetoComplexo =
                    JsonConvert.SerializeObject(objetoComplexo);
                ArmazenarValorCache(
                    "TesteObjetoComplexo", strObjetoComplexo);
            }
            else
            {
                objetoComplexo = JsonConvert
                    .DeserializeObject<TipoComplexo>(strObjetoComplexo);
            }
            ViewBag.ObjetoComplexo = objetoComplexo;

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
