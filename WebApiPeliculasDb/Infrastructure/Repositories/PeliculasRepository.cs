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

        public Task ActualizarPelicula(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }

        public Task EliminarPelicula(int id)
        {
            throw new NotImplementedException();
        }

        public Task GuardarPelicula(Pelicula pelicula)
        {
            throw new NotImplementedException();
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
