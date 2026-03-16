using WebApiPeliculasDb.Entities;
using WebApiPeliculasDb.Features.Peliculas.Interfaces;
using WebApiPeliculasDb.Infrastructure.Interfaces;

namespace WebApiPeliculasDb.Features.Peliculas.AppServices
{
    public class CategoriasAppService : ICategoriasAppService
    {
        private readonly ICategoriasRepository categoriasRepository;
        public CategoriasAppService(ICategoriasRepository categoriasRepository)
        {
            this.categoriasRepository = categoriasRepository;
        }
        public async Task ActualizarCategoria(Categoria categoria)
        {
            await categoriasRepository.ActualizarCategoria(categoria);
        }

        public async Task GuardarCategoria(Categoria categoria)
        {
            await categoriasRepository.GuardarCategoria(categoria);
        }

        public async Task<List<Categoria>> ObtenerCategorias()
        {
           return await categoriasRepository.ObtenerCategorias();
        }
    }
}
