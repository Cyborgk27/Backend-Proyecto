using Distribuidora_MC_DB.IRepositories;
using Distribuidora_MC_DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Distribuidora_MC_DB.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext ApplicationDbContext)
        {
            _context = ApplicationDbContext;
        }

        // CREATE
        public async Task AgregarProductoAsync(Producto producto)
        {
            _context.Set<Producto>().Add(producto);
            await _context.SaveChangesAsync();
        }

        // READ
        public async Task<Producto> ObtenerProductoPorIdAsync(int productoId)
        {
            return await _context.Set<Producto>().FindAsync(productoId);
        }

        public async Task<IEnumerable<Producto>> ObtenerTodosLosProductosAsync()
        {
            return await _context.Set<Producto>().ToListAsync();
        }

        // UPDATE
        public async Task ActualizarProductoAsync(Producto producto)
        {
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // DELETE
        public async Task EliminarProductoAsync(int productoId)
        {
            var producto = await _context.Set<Producto>().FindAsync(productoId);
            if (producto != null)
            {
                _context.Set<Producto>().Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
