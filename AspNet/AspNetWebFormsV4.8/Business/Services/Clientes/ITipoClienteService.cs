using AspNetWebFormsV4._8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWebFormsV4._8.Business.Services.Clientes
{
    public interface ITipoClienteService
    {
        Task<IEnumerable<CatTipoCliente>> GetAllTipoClientesAsync();
        Task<CatTipoCliente> GetTipoClienteByIdAsync(int id);
    }
}
