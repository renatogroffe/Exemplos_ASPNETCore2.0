using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Data.SqlClient;

namespace ExemploMiddleware2
{
    public class ChecagemIndisponibilidade
    {
        private readonly RequestDelegate _next;
        private readonly string _strConexao;

        public ChecagemIndisponibilidade(RequestDelegate next,
            string strConexao)
        {
            _next = next;
            _strConexao = strConexao;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string mensagem = null;

            using (SqlConnection conexao = new SqlConnection(_strConexao))
            {
                conexao.Open();

                SqlCommand cmd = conexao.CreateCommand();
                cmd.CommandText =
                    "SELECT TOP 1 Mensagem FROM dbo.Indisponibilidade " +
                    "WHERE @DataProcessamento BETWEEN InicioIndisponibilidade " +
                      "AND TerminoIndisponibilidade " +
                    "ORDER BY InicioIndisponibilidade";
                cmd.Parameters.Add("@DataProcessamento",
                    SqlDbType.DateTime).Value = DateTime.Now;

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    mensagem = reader["Mensagem"].ToString();

                conexao.Close();
            }

            if (mensagem == null)
                await _next(httpContext);
            else
            {
                httpContext.Response.StatusCode = 403;
                await httpContext.Response.WriteAsync(
                    $"<h1>{mensagem}</h1>");
            }
        }
    }

    public static class ChecagemIndisponibilidadeExtensions
    {
        public static IApplicationBuilder UseChecagemIndisponibilidade(
            this IApplicationBuilder builder,
            string connectionString)
        {
            return builder.UseMiddleware<ChecagemIndisponibilidade>(
                connectionString);
        }
    }
}
