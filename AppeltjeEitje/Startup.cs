﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppeltjeEitje.Data;
using AppeltjeEitje.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppeltjeEitje
{
    public class Startup
    {
        private readonly IConfiguration _congif;

        public Startup(IConfiguration config)
        {
            _congif = config;
        }
        
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppelEiContext>(cfg =>
            {
                cfg.UseSqlServer(_congif.GetConnectionString("AppelEiConnectionString"));
            });

            services.AddTransient<AppelEiSeed>();

            services.AddTransient<IMailService, NullMailService>();

            services.AddMvc();
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
                app.UseExceptionHandler("/error");
            }
            app.UseStaticFiles();
            app.UseNodeModules(env);

            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default", "{controller}/{action}/{id?}", new { controller = "App", Action = "Index" });
            });
        }
    }
}
