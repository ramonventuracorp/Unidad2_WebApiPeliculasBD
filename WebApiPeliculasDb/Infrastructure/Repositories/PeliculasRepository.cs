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

            await peliculasDbContext.SaveChangesAsync();
        }

        public Task EliminarPelicula(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GuardarPelicula(Pelicula pelicula)
        {
            peliculasDbContext.Peliculas.Add(pelicula);
            await peliculasDbContext.SaveChangesAsync();
        }

        public Task<Pelicula> ObtenerPeliculaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Pelicula>> ObtenerPeliculas()
        {
            return await peliculasDbContext.Peliculas.ToListAsync();
        }
    }
}
