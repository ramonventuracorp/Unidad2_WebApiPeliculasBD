using Microsoft.EntityFrameworkCore;
using WebApiPeliculasDb.Entities;

namespace WebApiPeliculasDb.Infrastructure.Databases
{
    public class PeliculasDbContext : DbContext
    {
        public PeliculasDbContext(DbContextOptions options) : base(options)
        {
        }

        // Tablas
        public DbSet<Pelicula> Peliculas => Set<Pelicula>();
        public DbSet<Categoria> Categorias => Set<Categoria>();


        // Mapeos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeo para tabla pelicula
            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.ToTable("Peliculas");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("INT");

                entity.Property(x => x.Sinopsis)
                .HasColumnName("Sinopsis")
                .HasColumnType("VARCHAR(500)");
            });
        }
    }
}
