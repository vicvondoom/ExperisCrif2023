using Serilog;

namespace SerilogWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // file di serilog
            string file = Path.Combine(builder.Environment.ContentRootPath, "wwwroot", "logs", "log.txt");
            builder.Host.UseSerilog(
                (ctx, lc) =>
                lc.MinimumLevel.Error() //gli dico di loggare da Debug in sù dei miei eventi!
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Error) // per Microsoft logga solo da Error in sù
                .WriteTo.File(file, rollingInterval: RollingInterval.Minute)
            );

// Livelli di log o severity: Verbose=0, Debug=1, Information=2, Warning=3, Error=4, Fatal=5

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