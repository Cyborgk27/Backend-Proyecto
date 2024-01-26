using Distribuidora_MC_DB.IRepositories;
using Distribuidora_MC_DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Distribuidora_MC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> ObtenerTodas()
        {
            var categorias = await _categoriaRepository.ObtenerTodasAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> ObtenerPorId(int id)
        {
            var categoria = await _categoriaRepository.ObtenerPorIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Crear([FromBody] Categoria categoria)
        {
            await _categoriaRepository.CrearAsync(categoria);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            await _categoriaRepository.ActualizarAsync(categoria);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            await _categoriaRepository.EliminarAsync(id);
            return NoContent();
        }
    }
}
