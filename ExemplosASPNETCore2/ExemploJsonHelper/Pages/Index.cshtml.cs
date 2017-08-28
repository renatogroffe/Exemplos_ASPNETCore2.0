using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExemploJsonHelper.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            TempData["DadosBrasil"] = new Pais()
            {
                Nome = "Brasil",
                Continente = "América do Sul",
                Capital = "Brasília",
                CodigoTelefonico = "55"
            };
        }
    }
}