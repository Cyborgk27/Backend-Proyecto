using System.ComponentModel.DataAnnotations;

namespace Distribuidora_MC_DB.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public string CodigoProducto { get; set; } = string.Empty;
        public string NombreProducto { get; set; } = string.Empty;
        public bool? Disponible { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public int? CategoriaId { get; set; }
        public int? ProveedorId { get; set; }

        // Propiedades de navegación
        public virtual Proveedor Proveedor { get; set; }
        public Categoria Categoria { get; set; }
        public virtual InformacionProducto InformacionProducto { get; set; }
        public virtual Precio Precio { get; set; }
    }
}
