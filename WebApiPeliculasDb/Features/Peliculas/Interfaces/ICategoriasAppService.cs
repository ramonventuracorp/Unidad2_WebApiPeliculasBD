using WebApiPeliculasDb.Entities;

namespace WebApiPeliculasDb.Features.Peliculas.Interfaces
{
    public interface ICategoriasAppService
    {
        Task<List<Categoria>> ObtenerCategorias();
        Task GuardarCategoria(Categoria categoria);
        Task ActualizarCategoria(Categoria categoria);
    }
}
