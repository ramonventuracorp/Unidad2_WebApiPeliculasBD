using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPeliculasDb.Entities;
using WebApiPeliculasDb.Infrastructure.Interfaces;

namespace WebApiPeliculasDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaRepository peliculaRepository;
        public PeliculasController(IPeliculaRepository peliculaRepository)
        {
            this.peliculaRepository = peliculaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPeliculas()
        {
            List<Pelicula> peliculas = 
                await peliculaRepository.ObtenerPeliculas();

            return Ok(peliculas);
        }
    }
}
