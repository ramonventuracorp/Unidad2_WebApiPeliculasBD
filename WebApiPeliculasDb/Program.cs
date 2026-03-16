using Microsoft.EntityFrameworkCore;
using WebApiPeliculasDb.Features.Peliculas.AppServices;
using WebApiPeliculasDb.Features.Peliculas.DomainServices;
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

// INYECCION DE DEPENDENCIAS DE SERVICIOS

// Servicios para las peliculas
builder.Services.AddScoped<
    IPeliculaRepository, 
    PeliculasRepository>();

builder.Services.AddScoped<
    IPeliculasAppService, 
    PeliculasAppService>();

// Servicios para las categorias
builder.Services.AddScoped<
    ICategoriasRepository,
    CategoriasRepository>();

builder.Services.AddScoped<
    ICategoriasAppService,
    CategoriasAppService>();

// Servicios de dominio
builder.Services.AddScoped<PeliculasDomainService>();

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
