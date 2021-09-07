using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using TechSystem.Infra.DataContext;
using TechSystem.Domain.Repositories.Contracts;
using TechSystem.Infra.Repositories;
using TechSystem.Domain.Handlers;
using TechSystem.Shared;

namespace TechSystem.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public static IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            // Carrega o appsettings no builder
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json");
            // Seta a configuração
            Configuration = builder.Build();
            // Pega a connection string do appsettings.json
            Settings.ConnectionString = $"{Configuration["connectionStrings"]}";
            System.Console.WriteLine(Settings.ConnectionString);


            // Carrega o MVC Core (Controllers, Rotas e CoreServiecs)
            services.AddMvcCore();

            // Injeção de Dependências.
            services.AddScoped<TechDataContext, TechDataContext>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<EmployeeHandler, EmployeeHandler>();
            services.AddTransient<IDependentRepository, DependentRepository>();
            services.AddTransient<DependentHandlers, DependentHandlers>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Seta os controllers como endpoints
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
