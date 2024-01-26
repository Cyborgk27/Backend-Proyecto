using Distribuidora_MC_DB.IRepositories;
using Distribuidora_MC_DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Distribuidora_MC_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorController(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        [HttpGet("{ruc}")]
        public async Task<ActionResult<Proveedor>> GetProveedor(int ruc)
        {
            var proveedor = await _proveedorRepository.ObtenerProveedorPorRUCAsync(ruc);
            if (proveedor == null)
            {
                return NotFound();
            }
            return Ok(proveedor);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedores()
        {
            var proveedores = await _proveedorRepository.ObtenerTodosLosProveedoresAsync();
            return Ok(proveedores);
        }

        [HttpPost]
        public async Task<ActionResult<Proveedor>> PostProveedor(Proveedor proveedor)
        {
            await _proveedorRepository.AgregarProveedorAsync(proveedor);
            return CreatedAtAction(nameof(GetProveedor), new { ruc = proveedor.Ruc }, proveedor);
        }

        [HttpPut("{ruc}")]
        public async Task<IActionResult> PutProveedor(int ruc, Proveedor proveedor)
        {
            if (ruc != proveedor.Ruc)
            {
                return BadRequest();
            }

            await _proveedorRepository.ActualizarProveedorAsync(proveedor);
            return NoContent();
        }

        [HttpDelete("{ruc}")]
        public async Task<IActionResult> DeleteProveedor(int ruc)
        {
            await _proveedorRepository.EliminarProveedorAsync(ruc);
            return NoContent();
        }
    }
}
