
using DeliveryGuyAPI.Configurations.Filters;
using DeliveryGuyAPI.Data;
using DeliveryGuyAPI.Models;
using DeliveryGuyAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeliveryGuyAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DeliveryGuyContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add ExceptionFilter to ALL Controlllers
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new MyExceptionFilter());
            }
            );

            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            builder.Services.AddScoped<IRepository<DeliveryGuy>, DeliveryGuyRepository>();

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
