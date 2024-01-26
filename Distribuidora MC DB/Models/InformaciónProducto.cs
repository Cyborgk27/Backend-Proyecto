using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora_MC_DB.Models
{
    public class InformacionProducto
    {
        [Key]
        public int ProductoId { get; set; }
        public string Imagen { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [ForeignKey("ProductoId")]  // Establece la relación de clave externa
        public virtual Producto Producto { get; set; }
    }
}
