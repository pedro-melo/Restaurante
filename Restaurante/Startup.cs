using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Restaurante
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
            services.AddCors();
            services.AddMvc().AddJsonOptions(ConfigureJson);

            services.AddDbContext<AppContextDb>(options =>
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TesteC;Trusted_Connection=True;MultipleActiveResultSets=true"));

            services.AddScoped(typeof(ApplicationCore.Interfaces.Repository.IGenericRepository<>), typeof(Infrastructure.Repository.GenericRepository<>));
            services.AddScoped<ApplicationCore.Interfaces.Service.IPratosService, ApplicationCore.Services.PratoService>();
            services.AddScoped<ApplicationCore.Interfaces.Service.IRestauranteService, ApplicationCore.Services.RestauranteService>();
        }

        private void ConfigureJson(MvcJsonOptions obj)
        {
            obj.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(
                options => options.WithOrigins("http://localhost:56031").AllowAnyMethod()
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
