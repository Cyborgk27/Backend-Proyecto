using Distribuidora_MC_DB;
using Distribuidora_MC_DB.Models;
using Distribuidora_MC_DB.Repositories;

public class Program
{
    static async Task Main(string[] args)
    {
        using (var _context = new ApplicationDbContext())
        {
            //Repositorios
            var productoRepository = new ProductoRepository(_context);
            var categoriaRepository = new CategoriaRepository(_context);

            //Crear
            //var nuevoProducto = new Producto { NombreProducto = "Barca Pequeña" };
            //await productoRepository.AgregarProductoAsync(nuevoProducto);
            //Console.WriteLine($"Producto creado con ID: {nuevoProducto.ProductoId}");

            var nuevaCategoria = new Categoria { CategoriaName = "Firecracker" };
            await categoriaRepository.CrearAsync(nuevaCategoria);
            Console.WriteLine($"Categoria creada con ID: {nuevaCategoria.CategoriaId}");

            
        }
    }
}