using Microsoft.EntityFrameworkCore;
using WebApiPeliculasDb.Entities;
using WebApiPeliculasDb.Infrastructure.Databases;
using WebApiPeliculasDb.Infrastructure.Interfaces;

namespace WebApiPeliculasDb.Infrastructure.Repositories
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly PeliculasDbContext peliculasDbContext;

        public CategoriasRepository(PeliculasDbContext peliculasDbContext)
        {
            this.peliculasDbContext = peliculasDbContext;
        }

        public async Task<List<Categoria>> ObtenerCategorias()
        {
            return await peliculasDbContext.Categorias.ToListAsync();
        }
    }
}
