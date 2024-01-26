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
    public class PrecioRepository : IPrecioRepository
    {
        private readonly ApplicationDbContext _context;

        public PrecioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Precio> GetPrecioByProductoIdAsync(int productoId)
        {
            return await _context.Precios.FirstOrDefaultAsync(p => p.ProductoId == productoId);
        }

        public async Task AddPrecioAsync(Precio precio)
        {
            _context.Precios.Add(precio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePrecioAsync(Precio precio)
        {
            _context.Entry(precio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePrecioAsync(int productoId)
        {
            var precio = await _context.Precios.FindAsync(productoId);
            if (precio != null)
            {
                _context.Precios.Remove(precio);
                await _context.SaveChangesAsync();
            }
        }
    }
}
