using System;
using System.IO;
using System.Reflection;
using Hat.Infrastructure.Mvc.Swagger;
using Hat.Infrastructure.Service;
using HybridModelBinding;
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
            services.AddControllers(opt =>
            {
                //opt.ModelBinderProviders.Insert(0, new FromRouteBodyModelBinderProvider());
            });
            services.AddMvc().AddHybridModelBinder(opt =>
            {
                opt.FallbackBindingOrder = new[] { Source.Route, Source.Body };
            });
            services.AddSwaggerGen(opt =>
            {
                opt.OperationFilter<MixedRouteBodyFilter>();
            });

            services.AddScoped<IFlowBuilder<Error>>(
                provider =>
                    new StandardBuilder()
                        .UseErrorType<Error>()
                        .HandleException((ex, logger) => logger.LogError(ex, ex.Message))
                        .MapExceptionToErrorOnDeconstruct(ex => new Error(ex.GetType().Name, ex.Message)));

            services.AddDomainServices();
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