using JewelryStore.DAL.Repositories;
using JewelryStore.DAL.Repositories.Interfaces;
using JewelryStore.DAL.UOW;
using JewelryStore.BLL.Services.Interfaces;
using JewelryStore.BLL.Services;
using Microsoft.EntityFrameworkCore;

namespace JewelryStore.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();

        builder.Services.AddDbContext<JewelryStoreDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Реєстрація репозиторіїв
        builder.Services.AddScoped<IClientRepository, ClientRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IPositionRepository, PositionRepository>();

        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IClientService, ClientService>();


        // Реєстрація Unit of Work
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Реєстрація AutoMapper (якщо ще не додано)
        builder.Services.AddAutoMapper(typeof(JewelryStore.BLL.Mapper.AutoMapperProfile));


        // Реєстрація DbContext як сервісу для репозиторіїв
        builder.Services.AddScoped<DbContext>(provider => provider.GetService<JewelryStoreDbContext>());


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

