using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ExemploADO.Controllers
{
    [Route("api/[controller]")]
    public class CotacoesController : Controller
    {
        [HttpGet]
        public ContentResult Get(
             [FromServices]IConfiguration config,
             string id)
        {
            string valorJSON;
            using (SqlConnection conexao = new SqlConnection(
                config.GetConnectionString("BaseCotacoes")))
            {
                var cmd = conexao.CreateCommand();
                cmd.CommandText =
                    "SELECT Sigla " +
                          ",Nome_Moeda " +
                          ",Ultima_Cotacao " +
                          ",Valor_Comercial AS 'Cotacoes.Comercial' " +
                          ",Valor_Turismo AS 'Cotacoes.Turismo' " +
                    "FROM dbo.Cotacoes " +
                    "ORDER BY Nome_Moeda " +
                    "FOR JSON PATH, ROOT('Moedas')";

                conexao.Open();
                valorJSON = (string)cmd.ExecuteScalar();
                conexao.Close();
            }

            return Content(valorJSON, "application/json");
        }
    }
}