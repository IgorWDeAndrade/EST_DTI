using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EST.DTI.Domain.Interfaces.Repositorio;
using EST.DTI.Domain.Interfaces.Servicos;
using EST.DTI.Infra.Data.Data;
using EST.DTI.Infra.Data.Repositorio;
using EST.DTI.Servico.Sevico;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EST.DTI.App.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["ConexaoSqlite:SqliteConnectionString"];

            services.AddDbContext<Contexto>(opt => opt.UseSqlite(connection));

            services.AddControllers();

            RegistraDI(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegistraDI(IServiceCollection services)
        {
            //Repositorios
            services.AddSingleton(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddSingleton<IRepositorioProdutos, RepositorioProdutos>();

            //Servicos
            services.AddSingleton(typeof(IServicoBase<>), typeof(ServicoBase<>));
            services.AddSingleton<IServicoProdutos, ServicoProdutos>();
        }
    }
}
