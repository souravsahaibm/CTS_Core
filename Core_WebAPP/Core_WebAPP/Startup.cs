using Core_WebAPP.Data;
using Core_WebAPP.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebAPP
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepository, Repository>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            string conn = _config.GetConnectionString("CTS_CoreConn"); //To test connectionstring
            services.AddDbContext<AppDBContext>(option => option.UseSqlServer(_config.GetConnectionString("CTS_CoreConn")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Run(async context => await context.Response.WriteAsync("Hi Sourav"));
            //app.UseDefaultFiles();
            //if (env.IsDevelopment())
            //    app.UseDeveloperExceptionPage();
            //else
            //    app.UseExceptionHandler("/error");
            //app.UseStaticFiles();
            app.UseExceptionHandler("/error");
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoint => {
                endpoint.MapRazorPages();
                endpoint.MapControllerRoute("default",
                    "/{controller}/{action}/{id?}",
                    new { controller = "App", action = "Index" });
                });

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
