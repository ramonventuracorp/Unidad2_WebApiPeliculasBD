using Microsoft.EntityFrameworkCore;
using WebApiPeliculasDb.Entities;
using WebApiPeliculasDb.Infrastructure.Databases;
using WebApiPeliculasDb.Infrastructure.Interfaces;

namespace WebApiPeliculasDb.Infrastructure.Repositories
{
    public class PeliculasRepository : IPeliculaRepository
    {
        private readonly PeliculasDbContext peliculasDbContext;

        public PeliculasRepository(PeliculasDbContext peliculasDbContext)
        {
            this.peliculasDbContext = peliculasDbContext;
        }

        public async Task ActualizarPelicula(Pelicula pelicula)
        {
            // Encontrar registro existente
            Pelicula peliculaExistente =
                peliculasDbContext.Peliculas
                .FirstOrDefault(x => x.Id == pelicula.Id)!;

            peliculaExistente.Nombre = pelicula.Nombre;
            peliculaExistente.Sinopsis = pelicula.Sinopsis;
            peliculaExistente.Puntuacion = pelicula.Puntuacion;
            peliculaExistente.Activo = pelicula.Activo;

            await peliculasDbContext.SaveChangesAsync();
        }

        public async Task EliminarPelicula(int id)
        {
            // Encontrar registro existente
            Pelicula peliculaExistente =
                peliculasDbContext.Peliculas
                .FirstOrDefault(x => x.Id == id)!;

            peliculaExistente.Activo = false;

            await peliculasDbContext.SaveChangesAsync();
        }

        public async Task GuardarPelicula(Pelicula pelicula)
        {
            peliculasDbContext.Peliculas.Add(pelicula);
            await peliculasDbContext.SaveChangesAsync();
        }

        public async Task<Pelicula> ObtenerPeliculaPorId(int id)
        {

            Pelicula? pelicula = 
                await peliculasDbContext.Peliculas.FirstOrDefaultAsync(x => x.Id == id);

            return pelicula ?? new Pelicula();
        }

        public async Task<List<Pelicula>> ObtenerPeliculas()
        {
            return await peliculasDbContext.Peliculas.ToListAsync();
        }
    }
}
