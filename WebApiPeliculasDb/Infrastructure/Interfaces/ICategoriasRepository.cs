using WebApiPeliculasDb.Entities;

namespace WebApiPeliculasDb.Infrastructure.Interfaces
{
    public interface ICategoriasRepository
    {
        Task<List<Categoria>> ObtenerCategorias(); 

    }
}
