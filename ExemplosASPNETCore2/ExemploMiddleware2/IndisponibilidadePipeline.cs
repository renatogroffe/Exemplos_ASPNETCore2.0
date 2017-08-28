using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace ExemploMiddleware2
{
    public class IndisponibilidadePipeline
    {
        public void Configure(IApplicationBuilder applicationBuilder)
        {
            IConfiguration config = (IConfiguration)applicationBuilder
                .ApplicationServices.GetService(typeof(IConfiguration));
            applicationBuilder.UseChecagemIndisponibilidade(
                config.GetConnectionString("ExemploMiddleware"));
        }
    }
}