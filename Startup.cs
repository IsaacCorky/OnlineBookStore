using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; } //set allows us to chage config

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<OnlineBookStoreDbContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:OnlineBookStoreConnection"]); //connect to MS SQL from the appsettings.json
            });

            services.AddScoped<IOnlineBookStoreRepository, EFOnlineBookStoreRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catpage",
                    "{category}/P{P:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page",
                    "/P{P:int}",
                    new { Controller = "Home", action = "Index", page = 1 });         // HOW IS THIS DIFFERENT

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", page = 1 });

                endpoints.MapControllerRoute("pagination",                  // TO THIS
                    "/P{P}",
                    new { Controller = "Home", action = "Index", page = 1 });

                endpoints.MapDefaultControllerRoute(); // make the url route look better
                   
                
                    // previous old code
                    //name: "default",
                    //pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedData.EnsurePopulated(app); //static method

        }
    }
}
