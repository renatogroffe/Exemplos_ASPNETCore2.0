using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ExemploCompressao.Controllers
{
    [Route("api/[controller]")]
    public class ProdutosController : Controller
    {
        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            List<Produto> produtos = new List<Produto>();

            Produto prod;
            for (int i = 1; i <= 100; i++)
            {
                prod = new Produto();
                prod.CodProduto = i.ToString("0000");
                prod.NomeProduto = string.Format("PRODUTO {0:0000}", i);
                prod.Preco = i / 10.0;

                produtos.Add(prod);
            }

            return produtos;
        }
    }
}