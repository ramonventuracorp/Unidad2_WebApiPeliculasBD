using WebApiPeliculasDb.Entities;
using WebApiPeliculasDb.Features.Peliculas.Interfaces;
using WebApiPeliculasDb.Infrastructure.Interfaces;

namespace WebApiPeliculasDb.Features.Peliculas.AppServices
{
    public class PeliculasAppService: IPeliculasAppService
    {
        private readonly IPeliculaRepository peliculaRepository;
        public PeliculasAppService(IPeliculaRepository peliculaRepository)
        {
            this.peliculaRepository = peliculaRepository;
        }

        public async Task ActualizarPelicula(Pelicula pelicula)
        {
            await peliculaRepository.ActualizarPelicula(pelicula);
        }

        public async Task GuardarPelicula(Pelicula pelicula)
        {
            await peliculaRepository.GuardarPelicula(pelicula);
        }


        // Metodo para listar peliculas
        public async Task<List<Pelicula>> ObtenerPeliculas()
        {
            return await peliculaRepository.ObtenerPeliculas();
        }
    }
}
