using Microsoft.EntityFrameworkCore;
using PropertiesAPI.Data;
using PropertiesAPI.Data.Repositories;
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
            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();


            app.MapSwagger().RequireAuthorization();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

//Exerc�cio aula 1

//Construa uma Api Web que gerencie uma lista de im�veis em mem�ria e que contenha as seguintes rotas:


//Criar requests no postman ou qualquer outra ferramenta para testes da api.

//Disponibilizar atrav�s de rep�sitorio no github.

//Extra

//- Utilizar Controllers
//- Incluir rotas para atualizar e remover im�veis.
//- Incluir Documenta��o OpenAPI com Swagger.