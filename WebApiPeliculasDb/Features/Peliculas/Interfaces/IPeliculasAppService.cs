using WebApiPeliculasDb.Entities;

namespace WebApiPeliculasDb.Features.Peliculas.Interfaces
{
    public interface IPeliculasAppService
    {
        Task<List<Pelicula>> ObtenerPeliculas();
        Task GuardarPelicula(Pelicula pelicula);
        Task ActualizarPelicula(Pelicula pelicula);
    }
}
