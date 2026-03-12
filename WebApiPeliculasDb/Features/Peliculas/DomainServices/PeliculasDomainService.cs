using WebApiPeliculasDb.Commons.Models;
using WebApiPeliculasDb.Entities;

namespace WebApiPeliculasDb.Features.Peliculas.DomainServices
{
    public class PeliculasDomainService
    {
        public PeliculasDomainService()
        {
            
        }


        public ApiResponse<Pelicula> GuardarPelicula(Pelicula pelicula)
        {
            ApiResponse<Pelicula> apiResponse = new ApiResponse<Pelicula>();
            apiResponse.Success = true;

            if (string.IsNullOrEmpty(pelicula.Nombre))
            {
                apiResponse.Success = false;
                apiResponse.Message = "El nombre de la pelicula no puede ir vacio";
            }

            if (pelicula.Puntuacion < 0)
            {
                apiResponse.Success = false;
                apiResponse.Message = "La puntuacion no puede ser negativa.";
            }


            apiResponse.Data = pelicula;
            return apiResponse;

        }
    }
}
