using System.ComponentModel.DataAnnotations;

namespace Distribuidora_MC_DB.Models
{
    public class Proveedor
    {
        [Key]
        public int Ruc { get; set; }
        public string NombreProveedor { get; set; } = string.Empty;
        public string EmailProveedor { get; set; }= string.Empty;
        public string TelefonoProveedor { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Navigation property
        public virtual List<Producto>? Productos { get; set; }
    }
}
