using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PrediktiveChallenge.Application.Apps;
using PrediktiveChallenge.Application.Interfaces;
using PrediktiveChallenge.Domain.Repositories;
using PrediktiveChallenge.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace PrediktiveChallenge.Api
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
            services.AddControllers();

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddScoped<ISetOfEquipmentRepository, SetOfEquipmentRepository>();
            services.AddScoped<ISetOfEquipmentApplication, SetOfEquipmentApplication>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PrediktiveChallenge.Api",
                    Description = "Prediktive Challenge",
                    Version = "v1"
                });

                var apiPath = Path.Combine(AppContext.BaseDirectory, "PrediktiveChallenge.Api.xml");

                c.IncludeXmlComments(apiPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc()
               .UseMvcWithDefaultRoute();

            app.UsePathBase("/prediktive-challenge-api");
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PrediktiveChallenge.Api");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
