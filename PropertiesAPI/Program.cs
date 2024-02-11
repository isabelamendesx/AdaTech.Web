using Microsoft.EntityFrameworkCore;
using PropertiesAPI.Data;
using PropertiesAPI.Data.Repositories;
using PropertiesAPI.Middleware;
using PropertiesAPI.Models;
using PropertiesAPI.Services;

namespace PropertiesAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IPropertyService, PropertyService>();
            builder.Services.AddScoped<IRepository<Property>, PropertyRepository>();


            builder.Services.AddDbContext<PropertyContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseTiming();

            app.UseErrorHandling();

            app.UseHttpsRedirection();

            app.MapSwagger().RequireAuthorization();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

//app.Use(async (context, next) =>
//{
//    // executado na ida
//    var start = DateTime.UtcNow;

//    // chamou o proximo
//    await next.Invoke(context);

//    //executado na volta
//    app.Logger.LogInformation($"Request {context.Request.Path}: {(DateTime.UtcNow - start).TotalMilliseconds}ms");
//});

//// Esse middleware vai encerrar o request (Terminating Middleware)
//// Não chama o próximo
//app.Use((HttpContext context, Func<Task> next) =>
//{
//    app.Logger.LogInformation("Terminating the Request");
//    return Task.CompletedTask;
//});