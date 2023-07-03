using concessionária.Context;
using concessionária.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ServerConnection")));

        builder.Services.AddScoped<IVeiculosRepository, VeiculosRepository>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Concessionária",
                Description = "CRUD de Veiculos",
                Contact = new OpenApiContact()
                {
                    Name = "Luiz",
                    Email = "luizabadi123@outlook.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Linkedin",
                    Url = new Uri("https://www.linkedin.com/in/luiz-fernando-oliveira-a90b35255/")
                }
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });



        var app = builder.Build();

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