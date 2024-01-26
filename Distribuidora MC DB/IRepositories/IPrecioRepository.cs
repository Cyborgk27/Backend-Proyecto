using Distribuidora_MC_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora_MC_DB.IRepositories
{
    public interface IPrecioRepository
    {
        Task<Precio> GetPrecioByProductoIdAsync(int productoId);
        Task AddPrecioAsync(Precio precio);
        Task UpdatePrecioAsync(Precio precio);
        Task DeletePrecioAsync(int productoId);
    }
}
