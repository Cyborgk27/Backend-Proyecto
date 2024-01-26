using Distribuidora_MC_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuidora_MC_DB.IRepositories
{
    public interface IInformacionProductoRepository
    {
        Task<InformacionProducto> GetInformacionProductoByProductoIdAsync(int productoId);
        Task AddInformacionProductoAsync(InformacionProducto informacionProducto);
        Task UpdateInformacionProductoAsync(InformacionProducto informacionProducto);
        Task DeleteInformacionProductoAsync(int productoId);
    }
}
