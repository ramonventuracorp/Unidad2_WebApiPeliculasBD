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

                entity.Property(x => x.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("VARCHAR(250)");

                entity.Property(x => x.Sinopsis)
                .HasColumnName("Sinopsis")
                .HasColumnType("VARCHAR(500)");

                entity.Property(x => x.FechaEstreno)
                .HasColumnName("FechaEstreno")
                .HasColumnType("Datetime");

                entity.Property(x => x.Puntuacion)
                .HasColumnName("Puntuacion")
                .HasColumnType("INT");

                entity.Property(x => x.CategoriaId)
                .HasColumnName("CategoriaId")
                .HasColumnType("INT");

                entity.Property(x => x.Activo)
                .HasColumnName("Activo")
                .HasColumnType("BIT")
                .HasDefaultValue(true);

                entity.Property(x => x.FechaAgrega)
                .HasColumnName("FechaAgrega")
                .HasColumnType("DATETIME")
                .HasDefaultValue(DateTime.Now);

            });

            // Mapeo de tabla de categorias
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("Categorias");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("INT");

                entity.Property(x => x.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("VARCHAR(250)");

                entity.Property(x => x.Activo)
                .HasColumnName("Activo")
                .HasColumnType("BIT")
                .HasDefaultValue(true);

                entity.Property(x => x.FechaAgrega)
                .HasColumnName("FechaAgrega")
                .HasColumnType("DATETIME")
                .HasDefaultValue(DateTime.Now);

            });
        }
    }
}
