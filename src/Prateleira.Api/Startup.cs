using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Prateleira.Infrastruture.Data.DataRegistration;
using System;
using System.Reflection;

namespace Prateleira.Api
{
    public class Startup
    {

        private static Uri UriExample =  new("http://example.com/terms");
        private static Uri UriGit     =  new("https://github.com/dcoxi");
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(opt =>
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            var assembly = AppDomain.CurrentDomain.Load("Prateleira.Application");
            services.AddMediatR(assembly);
          
            
            services.AddDataRegistration(_configuration);

            #region Swagger

            _ = services.AddSwaggerGen(o =>
             {
                 o.SwaggerDoc("v1", new OpenApiInfo
                 {
                     Version = "v1",
                     Title = "Prateleira.Api",
                     Description = "API CRUD de gestão de prateleira",
                     TermsOfService = UriExample,
                     Contact = new OpenApiContact
                     {
                         Name = "Dilangue Pedro Coxi",
                         Email = "d_pc1@hotmail.com",
                         Url = UriGit
                     },
                     License = new OpenApiLicense
                     {
                         Name = "Use under LICX",
                         Url  =  UriExample
                     }
                 });
             });

            #endregion Swagger
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            #region Swagger

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Prateleira");
                s.RoutePrefix = string.Empty;
            });

            #endregion Swagger

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
