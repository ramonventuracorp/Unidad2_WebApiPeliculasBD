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

        public async Task ActualizarCategoria(Categoria categoria)
        {
            Categoria? categoriaExistente =
                await peliculasDbContext.Categorias
                .FirstOrDefaultAsync(x => x.Id == categoria.Id);

            if (categoriaExistente != null)
            {
                categoriaExistente.Nombre = categoria.Nombre;
                categoriaExistente.Activo = categoria.Activo;
                await peliculasDbContext.SaveChangesAsync();
            }
        }

        public async Task GuardarCategoria(Categoria categoria)
        {
            await peliculasDbContext.Categorias.AddAsync(categoria);
            await peliculasDbContext.SaveChangesAsync();
        }

        public async Task<List<Categoria>> ObtenerCategorias()
        {
            return await peliculasDbContext.Categorias.ToListAsync();
        }
    }
}
