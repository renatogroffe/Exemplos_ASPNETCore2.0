using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExemploRedisCache
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Para testes em ambiente Windows é
            // possível a montagem de um servidor Redis
            // a partir de um container Docker.
            // Um novo container para uso do Redis pode
            // ser gerado por meio do seguinte comando:
            // docker run --name redislocal -p 6379:6379 -d redis:alpine
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration =
                    Configuration.GetSection("ConexaoRedis").Value;
                options.InstanceName = "TesteRedisCache";
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}