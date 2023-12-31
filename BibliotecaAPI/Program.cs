using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            string cnStr = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<BibliotecaDbContext>(opt => opt.UseSqlServer(cnStr));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins("https://localhost:7076");
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //// Qui apro le policy CORS per far entrare chiunque!
            //app.UseCors(cors =>
            //    cors.AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .AllowCredentials()
            //    .SetIsOriginAllowed(origin => true)
            //    );
            app.UseCors();

            app.MapControllers();

            app.Run();
        }
    }
}