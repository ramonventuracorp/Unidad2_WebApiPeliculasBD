using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPeliculasDb.Features.Peliculas.Interfaces;

namespace WebApiPeliculasDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasAppService categoriasAppService;
        public CategoriasController(ICategoriasAppService categoriasAppService)
        {
            this.categoriasAppService = categoriasAppService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerCategorias()
        {
            var respuesta = await categoriasAppService.ObtenerCategorias();
            return Ok(respuesta);
        }
    }
}
