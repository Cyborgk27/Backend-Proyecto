using Distribuidora_MC_DB.IRepositories;
using Distribuidora_MC_DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Distribuidora_MC_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrecioController : ControllerBase
    {
        private readonly IPrecioRepository _precioRepository;

        public PrecioController(IPrecioRepository precioRepository)
        {
            _precioRepository = precioRepository;
        }

        [HttpGet("{productoId}")]
        public async Task<ActionResult<Precio>> GetPrecio(int productoId)
        {
            var precio = await _precioRepository.GetPrecioByProductoIdAsync(productoId);
            if (precio == null)
            {
                return NotFound();
            }
            return Ok(precio);
        }

        [HttpPost]
        public async Task<ActionResult<Precio>> PostPrecio(Precio precio)
        {
            await _precioRepository.AddPrecioAsync(precio);
            return CreatedAtAction(nameof(GetPrecio), new { productoId = precio.ProductoId }, precio);
        }

        [HttpPut("{productoId}")]
        public async Task<IActionResult> PutPrecio(int productoId, Precio precio)
        {
            if (productoId != precio.ProductoId)
            {
                return BadRequest();
            }

            await _precioRepository.UpdatePrecioAsync(precio);
            return NoContent();
        }

        [HttpDelete("{productoId}")]
        public async Task<IActionResult> DeletePrecio(int productoId)
        {
            await _precioRepository.DeletePrecioAsync(productoId);
            return NoContent();
        }
    }
}
