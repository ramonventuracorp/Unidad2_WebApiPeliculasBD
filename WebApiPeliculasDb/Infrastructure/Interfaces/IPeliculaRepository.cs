using WebApiPeliculasDb.Entities;

namespace WebApiPeliculasDb.Infrastructure.Interfaces
{
    public interface IPeliculaRepository
    {
        Task<List<Pelicula>> ObtenerPeliculas();
        Task<Pelicula> ObtenerPeliculaPorId(int id);
        Task GuardarPelicula(Pelicula pelicula);
        Task ActualizarPelicula(Pelicula pelicula);
        Task EliminarPelicula(int id);
    }
}
