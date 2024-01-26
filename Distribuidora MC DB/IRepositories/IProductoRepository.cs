using Distribuidora_MC_DB.Models;

namespace Distribuidora_MC_DB.IRepositories
{
    public interface IProductoRepository
    {
        // CREATE
        Task AgregarProductoAsync(Producto producto);

        // READ
        Task<Producto> ObtenerProductoPorIdAsync(int productoId);
        Task<IEnumerable<Producto>> ObtenerTodosLosProductosAsync();

        // UPDATE
        Task ActualizarProductoAsync(Producto producto);

        // DELETE
        Task EliminarProductoAsync(int productoId);
    }
}
