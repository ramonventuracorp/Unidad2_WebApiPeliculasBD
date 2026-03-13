using WebApiPeliculasDb.Commons.Models;
using WebApiPeliculasDb.Entities;
using WebApiPeliculasDb.Features.Peliculas.Dtos;

namespace WebApiPeliculasDb.Features.Peliculas.Interfaces
{
    public interface IPeliculasAppService
    {
        Task<List<Pelicula>> ObtenerPeliculas();
        Task<ApiResponse<Pelicula>> GuardarPelicula(Pelicula pelicula);
        Task ActualizarPelicula(Pelicula pelicula);
        Task<Pelicula> ObtenerPeliculaPorId(int id);
        Task InactivarPelicula(int id);
        Task<List<PeliculaDto>> ObtenerPeliculasParaUsuario();
    }
}
