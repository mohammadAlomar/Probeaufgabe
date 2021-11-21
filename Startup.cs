using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Probeaufgabe.AppContext;
using Probeaufgabe.Repository;

namespace Probeaufgabe
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
            var dataSource = Configuration["DataSource"] ?? "localhost";
            var port = Configuration["Port"] ?? "1433";
            var database = Configuration["Database"] ?? "CompanyHändler";
            var userName = Configuration["UserID"] ?? "SA";
            var password = Configuration["Password"] ?? "Abotark12-9-1987";
            
            services.AddDbContext<AppDbContext>(o =>

                o.UseSqlServer($"Server={dataSource},{port};Database={database};User ID={userName};Password={password}",

                sqlserver => sqlserver.MigrationsAssembly("WebApplication1")

            )) ;
            
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressLink, AddressLinkRepository>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
