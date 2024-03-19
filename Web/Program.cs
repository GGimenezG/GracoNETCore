using Core.Interfaces;
using Core.Interfaces.Repositorios;
using Core.Interfaces.Servicios;
using Core.Servicios;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.Services;
using System.Configuration;
using System.Reflection;
using System.Text;
using Web.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Gracosoft .NET CORe",
        Description = "Aplicación elaborada durante las clases del 1 al 9 de la asignatura .Net Core, se encarga del procesamiento de la lógica de un videojuego RPG.",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Guillermo Giménez",
            Url = new Uri("https://github.com/GGimenezG/GracoNETCore")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // To Enable authorization using Swagger (JWT)
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });


    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddControllers();

builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IPersonajeRepository), typeof(PersonajeRepository));
builder.Services.AddScoped(typeof(IEnemigoRepository), typeof(EnemigoRepository));
builder.Services.AddScoped(typeof(IObjetosRepository), typeof(ObjetosRepository));
builder.Services.AddScoped(typeof(IRecompensaRepository), typeof(RecompensaRepository));
builder.Services.AddScoped(typeof(ITipoPersonajeRepository), typeof(TipoPersonajeRepository));
builder.Services.AddScoped(typeof(IPersonajeService), typeof(PersonajeService));
builder.Services.AddScoped(typeof(IEnemigoService), typeof(EnemigoService));
builder.Services.AddScoped(typeof(IObjetosService), typeof(ObjetosService));
builder.Services.AddScoped(typeof(IRecompensaService), typeof(RecompensaServices));
builder.Services.AddScoped(typeof(ITipoPersonajeService), typeof(TipoPersonajeService));
builder.Services.AddScoped<IUserService, UserService>();



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
app.UseMiddleware<JwtMiddleware>();
//app.Services.a

app.UseAuthentication();
app.UseAuthorization();

app.Run();

