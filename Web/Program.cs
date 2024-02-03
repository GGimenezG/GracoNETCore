using Core.Interfaces;
using Core.Interfaces.Repositorios;
using Core.Servicios;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IPersonajeRepository), typeof(PersonajeRepository));
builder.Services.AddScoped(typeof(IPersonajeService), typeof(PersonajeService));

/*builder.Services.AddDbContext<AppDbContext>(options => 
                    options.UseNpgsql("Host=dpg-clupqhmg1b2c73cacl4g-a;Server=dpg-clupqhmg1b2c73cacl4g-a.oregon-postgres.render.com;Port=5432;Database=gracoapidb;Username=graco;Password=d16mVIlilx3OFVzXgb0AW5VYnTOv0pMT"
                     ,b => b.MigrationsAssembly("Infrastructure")
                )
                    
            );*/
builder.Services.AddDbContext<AppDbContext>(options => 
                    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.Services.a



app.Run();

