using Distribuidora_MC_DB.IRepositories;
using Distribuidora_MC_DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Distribuidora_MC_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InformacionProductoController : ControllerBase
    {
        private readonly IInformacionProductoRepository _informacionProductoRepository;

        public InformacionProductoController(IInformacionProductoRepository informacionProductoRepository)
        {
            _informacionProductoRepository = informacionProductoRepository;
        }

        [HttpGet("{productoId}")]
        public async Task<ActionResult<InformacionProducto>> GetInformacionProducto(int productoId)
        {
            var informacionProducto = await _informacionProductoRepository.GetInformacionProductoByProductoIdAsync(productoId);
            if (informacionProducto == null)
            {
                return NotFound();
            }
            return Ok(informacionProducto);
        }

        [HttpPost]
        public async Task<ActionResult<InformacionProducto>> PostInformacionProducto(InformacionProducto informacionProducto)
        {
            await _informacionProductoRepository.AddInformacionProductoAsync(informacionProducto);
            return CreatedAtAction(nameof(GetInformacionProducto), new { productoId = informacionProducto.ProductoId }, informacionProducto);
        }

        [HttpPut("{productoId}")]
        public async Task<IActionResult> PutInformacionProducto(int productoId, InformacionProducto informacionProducto)
        {
            if (productoId != informacionProducto.ProductoId)
            {
                return BadRequest();
            }

            await _informacionProductoRepository.UpdateInformacionProductoAsync(informacionProducto);
            return NoContent();
        }

        [HttpDelete("{productoId}")]
        public async Task<IActionResult> DeleteInformacionProducto(int productoId)
        {
            await _informacionProductoRepository.DeleteInformacionProductoAsync(productoId);
            return NoContent();
        }
    }
}
