using System.ComponentModel.DataAnnotations;

namespace Distribuidora_MC_DB.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; } 
        public string CategoriaName { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public virtual List<Producto>? Productos { get; set; }
    }
}
