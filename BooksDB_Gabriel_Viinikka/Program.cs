using BooksDB_Gabriel_Viinikka.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace BooksDB_Gabriel_Viinikka
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "No Environment found";
            Console.WriteLine($"Environment set to {env.ToUpper()}");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            var connectionString = builder.Configuration.GetConnectionString("BooksDb");
            builder.Services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseSqlServer(connectionString).LogTo(message => Debug.WriteLine(message)).EnableSensitiveDataLogging();
            });


           builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
