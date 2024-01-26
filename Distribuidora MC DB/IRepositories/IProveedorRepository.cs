using Distribuidora_MC_DB.Models;

namespace Distribuidora_MC_DB.IRepositories
{
    public interface IProveedorRepository
    {
        Task AgregarProveedorAsync(Proveedor proveedor);
        Task<Proveedor> ObtenerProveedorPorRUCAsync(int ruc);
        Task<IEnumerable<Proveedor>> ObtenerTodosLosProveedoresAsync();
        Task ActualizarProveedorAsync(Proveedor proveedor);
        Task EliminarProveedorAsync(int ruc);
    }
}
