using Microsoft.EntityFrameworkCore;
using NegozioCellulariWeb.Models;

namespace NegozioCellulariWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            string cnStr = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<NegozioCellulariContext>(opt =>
                opt.UseSqlServer(cnStr)
            );

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Cellulari}/{action=Index}/{id?}");

            app.Run();
        }
    }
}