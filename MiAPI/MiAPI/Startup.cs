using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MiAPI.Custome;
using MiAPI.Persistence;
using MiAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MiAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public object StopWatch { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuración de los servicios que utilizará mi aplicación
            services.AddDbContext<ApplicationContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );

            // Inyección de servicios necesarios para la aplicación
            services.AddTransient<ITodoService, TodoService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFacetory)
        {
            loggerFacetory
                .AddEventSourceLogger()
                .AddConsole();

            var logger = loggerFacetory.CreateLogger("Profiler");

            // Configuración de Pipeline de ASP NET Core
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                var watch = Stopwatch.StartNew();
                await next();
                var path = context.Response.StatusCode;
                var statusCode = context.Response.StatusCode;
                var logString = $"Pat h= '{path}', status = {statusCode}, time = {watch.Elapsed}";

                logger.LogInformation(logString);
            });


            app.UseMiddleware<SimpleProfilerMiddleware>();
            app.UseMvc();

        }
    }
}
