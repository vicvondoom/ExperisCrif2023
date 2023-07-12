using Microsoft.EntityFrameworkCore;
using NegozioMusicaWeb.Models;

namespace NegozioMusicaWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Prima di fare la Build, posso iniettare servizi di qualunque tipo

            // Voglio iniettare il MusicaContext
            // Recupero la stringa di connessione dall'appsettings.json
            string connString = builder.Configuration.GetConnectionString("Sviluppo");
            // Ora inietto il database context nel sistema
            builder.Services.AddDbContext<MusicaContext>(
                options => options.UseSqlServer(connString)
            );
            // Ho appena iniettato un istanza pronta del MusicaContext nel sistema!


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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}