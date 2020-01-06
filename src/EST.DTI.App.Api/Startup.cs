using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EST.DTI.App.Api.ViewModel;
using EST.DTI.Domain.Entity;
using EST.DTI.Domain.Interfaces.Repositorio;
using EST.DTI.Domain.Interfaces.Servicos;
using EST.DTI.Infra.Data.Data;
using EST.DTI.Infra.Data.Repositorio;
using EST.DTI.Servico.Sevico;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
            RegistraDI(services);
            RegistrarDIAutoMapper(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<Contexto>(opt => opt.UseSqlite(connection));
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }


        private void RegistraDI(IServiceCollection services)
        {
            //Repositorios
            services.AddSingleton(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<IRepositorioProdutos, RepositorioProdutos>();

            //Servicos
            services.AddSingleton(typeof(IServicoBase<>), typeof(ServicoBase<>));
            services.AddScoped<IServicoProdutos, ServicoProdutos>();

        }

        private void RegistrarDIAutoMapper(IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }

    }
}
