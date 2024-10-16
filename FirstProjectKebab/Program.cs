using KebabStore.Application.Services;
using KebabStore.DataAccess;
using KebabStore.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FirstProjectKebab;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<KebabStoreDbContext>(
            options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(KebabStoreDbContext)));
            });

        builder.Services.AddScoped<IKebabsService, KebabService>(); // ������ ���� � Core-Abstractions
        builder.Services.AddScoped<IKebabsRepository, KebabsRepository>();

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

        app.UseCors(x =>
        {
            x.WithHeaders().AllowAnyHeader();
            x.WithOrigins("http://localhost:3000");
            x.WithMethods().AllowAnyMethod();
        });

        app.Run();
    }
}
