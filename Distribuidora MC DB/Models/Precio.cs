using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora_MC_DB.Models
{
    public class Precio
    {
        [Key]  // Usa la misma clave que en Producto
        public int ProductoId { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public float PrecioEfectivo { get; set; }
        public float PrecioCredito { get; set; }
        public float PrecioUnidad { get; set; }

        // Propiedad de navegación
        [ForeignKey("ProductoId")]  // Establece la relación de clave externa
        public virtual Producto Producto { get; set; }
    }
}
