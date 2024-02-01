using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.AspNetCore.Identity;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Optivem.Framework.Core.Domain;
using DataLayer.Models;
using Application;
using Microsoft.Extensions.Logging;
using Serilog;

namespace MovieFans
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);



            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
               .WriteTo.Console().WriteTo.File("Logs/Logs.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();

            builder.Host.UseSerilog();


            builder.Services.AddControllersWithViews();



            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionString"]);
                //options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });


            builder.Services.AddScoped<IUser, UserService>();

            builder.Services.AddScoped<IGenre, GenreService>();



            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {

                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.LogoutPath = "/Account/Logout";
                options.SlidingExpiration = true;


            });


            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}