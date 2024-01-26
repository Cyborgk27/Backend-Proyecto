using Distribuidora_MC_DB.IRepositories;
using Distribuidora_MC_DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Distribuidora_MC_DB.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProveedorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AgregarProveedorAsync(Proveedor proveedor)
        {
            _dbContext.Set<Proveedor>().Add(proveedor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Proveedor> ObtenerProveedorPorRUCAsync(int ruc)
        {
            return await _dbContext.Set<Proveedor>().FindAsync(ruc);
        }

        public async Task<IEnumerable<Proveedor>> ObtenerTodosLosProveedoresAsync()
        {
            return await _dbContext.Set<Proveedor>().ToListAsync();
        }

        public async Task ActualizarProveedorAsync(Proveedor proveedor)
        {
            _dbContext.Entry(proveedor).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task EliminarProveedorAsync(int ruc)
        {
            var proveedor = await _dbContext.Set<Proveedor>().FindAsync(ruc);
            if (proveedor != null)
            {
                _dbContext.Set<Proveedor>().Remove(proveedor);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
