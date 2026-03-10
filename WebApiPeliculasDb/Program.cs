using Microsoft.EntityFrameworkCore;
using WebApiPeliculasDb.Features.Peliculas.AppServices;
using WebApiPeliculasDb.Features.Peliculas.Interfaces;
using WebApiPeliculasDb.Infrastructure.Databases;
using WebApiPeliculasDb.Infrastructure.Interfaces;
using WebApiPeliculasDb.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Base de datos
builder.Services.AddDbContext<PeliculasDbContext>(
    options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(
            "DbPeliculasConnectionString"
        )
    )
 );

// Inyeccion de dependencias de servicios
builder.Services.AddScoped<
    IPeliculaRepository, 
    PeliculasRepository>();

builder.Services.AddScoped<
    IPeliculasAppService, 
    PeliculasAppService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
