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

builder.Services.AddDbContext<AppDbContext>(options => 
                    options.UseNpgsql(""
                )
                    
            );
/*builder.Services.AddDbContext<AppDbContext>(options => 
                    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
            );*/

var app = builder.Build();

//app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.Services.a



app.Run();

