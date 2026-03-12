using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPeliculasDb.Entities;
using WebApiPeliculasDb.Features.Peliculas.Interfaces;
using WebApiPeliculasDb.Infrastructure.Interfaces;

namespace WebApiPeliculasDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculasAppService peliculasAppService;
        public PeliculasController(IPeliculasAppService peliculasAppService)
        {
            this.peliculasAppService = peliculasAppService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPeliculas()
        {
            List<Pelicula> peliculas = 
                await peliculasAppService.ObtenerPeliculas();

            return Ok(peliculas);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObtenerPeliculaPorId([FromRoute] int id)
        {
            Pelicula pelicula =
                await peliculasAppService.ObtenerPeliculaPorId(id);

            return Ok(pelicula);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarPelicula(
            [FromBody] Pelicula pelicula)
        {
            var respuesta = await peliculasAppService.GuardarPelicula(pelicula);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarPelicula(
            [FromBody] Pelicula pelicula)
        {
            await peliculasAppService.ActualizarPelicula(pelicula);
            return Ok("Pelicula Actualizada");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> InactivarPelicula([FromRoute] int id)
        {
            await peliculasAppService.InactivarPelicula(id);

            return Ok("Registro Inactivado");
        }
    }
}
