using Distribuidora_MC_DB.IRepositories;
using Distribuidora_MC_DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora_MC_DB.Repositories
{
    public class InformacionProductoRepository : IInformacionProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public InformacionProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<InformacionProducto> GetInformacionProductoByProductoIdAsync(int productoId)
        {
            return await _context.informacionProductos.FirstOrDefaultAsync(ip => ip.ProductoId == productoId);
        }

        public async Task AddInformacionProductoAsync(InformacionProducto informacionProducto)
        {
            _context.informacionProductos.Add(informacionProducto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInformacionProductoAsync(InformacionProducto informacionProducto)
        {
            _context.Entry(informacionProducto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInformacionProductoAsync(int productoId)
        {
            var informacionProducto = await _context.informacionProductos.FindAsync(productoId);
            if (informacionProducto != null)
            {
                _context.informacionProductos.Remove(informacionProducto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
