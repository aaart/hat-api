using System;
using System.IO;
using System.Reflection;
using Hat.Infrastructure.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PipeSharp;
using Serilog;

namespace Hat.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            
            services.AddScoped<IFlowBuilder<Error>>(
                provider => 
                    new StandardBuilder()
                        .UseErrorType<Error>()
                        .HandleException((ex, logger) => logger.LogError(ex, ex.Message))
                        .MapExceptionToErrorOnDeconstruct(ex => new Error(ex.GetType().Name, ex.Message)));
            
            services.RegisterDomainServices();
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HAT API v1");
                c.RoutePrefix = string.Empty;
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // this method can not be found.
                // c.IncludeXmlComments(xmlPath);
            });

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllerRoute("default", "{controller}/{action}/{id?}"); });
        }
    }
}