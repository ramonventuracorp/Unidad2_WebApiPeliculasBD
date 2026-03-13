using WebApiPeliculasDb.Commons.Models;
using WebApiPeliculasDb.Entities;
using WebApiPeliculasDb.Features.Peliculas.DomainServices;
using WebApiPeliculasDb.Features.Peliculas.Dtos;
using WebApiPeliculasDb.Features.Peliculas.Interfaces;
using WebApiPeliculasDb.Infrastructure.Interfaces;

namespace WebApiPeliculasDb.Features.Peliculas.AppServices
{
    public class PeliculasAppService: IPeliculasAppService
    {
        private readonly IPeliculaRepository peliculaRepository;
        private readonly ICategoriasRepository categoriasRepository;
        private readonly PeliculasDomainService peliculasDomainService;
        public PeliculasAppService(IPeliculaRepository peliculaRepository, 
            PeliculasDomainService peliculasDomainService, 
            ICategoriasRepository categoriasRepository)
        {
            this.peliculaRepository = peliculaRepository;
            this.peliculasDomainService = peliculasDomainService;
            this.categoriasRepository = categoriasRepository;
        }

        public async Task ActualizarPelicula(Pelicula pelicula)
        {
            await peliculaRepository.ActualizarPelicula(pelicula);
        }

        public async Task<ApiResponse<Pelicula>> GuardarPelicula(Pelicula pelicula)
        {
            ApiResponse<Pelicula> apiResponseResult =
                peliculasDomainService.GuardarPelicula(pelicula);
            try
            {
                if (apiResponseResult.Success)
                {
                    await peliculaRepository.GuardarPelicula(pelicula);
                }

                return apiResponseResult;
            }
            catch (Exception ex)
            {
                apiResponseResult.Success = false;
                apiResponseResult.Message = ex.Message;
                return apiResponseResult;
            }

        }

        public async Task InactivarPelicula(int id)
        {
            await peliculaRepository.EliminarPelicula(id);
        }

        public async Task<Pelicula> ObtenerPeliculaPorId(int id)
        {
            return await peliculaRepository.ObtenerPeliculaPorId(id);
        }


        // Metodo para listar peliculas
        public async Task<List<Pelicula>> ObtenerPeliculas()
        {
            return await peliculaRepository.ObtenerPeliculas();
        }

        public async Task<List<PeliculaDto>> ObtenerPeliculasParaUsuario()
        {
            List<Categoria> categorias = await categoriasRepository.ObtenerCategorias();
            List<Pelicula> peliculas = await peliculaRepository.ObtenerPeliculas();

            var peliculasConCategoria =
                (
                    from p in peliculas
                    join c in categorias on p.CategoriaId equals c.Id
                    select new PeliculaDto
                    {
                        Nombre = p.Nombre,
                        Sinopsis = p.Sinopsis,
                        Categoria = c.Nombre,
                    }
                ).ToList();

            return peliculasConCategoria;
        }
    }
}
