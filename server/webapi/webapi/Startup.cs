using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using BLL;
namespace webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddCors(c =>
            {
                c.AddPolicy("AccountSystems", options => options.AllowAnyOrigin().AllowAnyMethod()
                 .AllowAnyHeader());
            });
            services.AddTransient<PersonalTypesBLL>();
            services.AddTransient<PersonalBLL>();
            services.AddTransient<InvestmentPolicyTypesBLL>();
            services.AddTransient<AccountBLL>();
            services.AddTransient<PersonalInAccountBLL>();

            services.AddDbContext<AccountSystem>(
            options => options.UseSqlServer("Data Source=DESKTOP-PAIK2HR;Initial Catalog=AccountSystem;Integrated Security=True"));


        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("AccountSystems");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
