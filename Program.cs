
using Microsoft.EntityFrameworkCore;
using Oficina.API.Context;
using Oficina.API.Models;
using Oficina.API.Repository;
using Oficina.API.Services;

namespace Oficina.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IRepository<Cliente>, Repository<Cliente>>();
            builder.Services.AddScoped<IRepository<Endereco>, Repository<Endereco>>();
            builder.Services.AddScoped<IRepository<Veiculo>, Repository<Veiculo>>();
            builder.Services.AddScoped<IService<Cliente>, ClienteService>();
            builder.Services.AddScoped<IEnderecoService, EnderecoService>();
            builder.Services.AddScoped<IVeiculoService, VeiculoService>();
            builder.Services.AddDbContext<OficinaContext>(options =>
            {
                //The name of the connection string is taken from appsetting.json under ConnectionStrings
                options.UseMySQL(builder.Configuration.GetConnectionString("OficinaDBContext"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
