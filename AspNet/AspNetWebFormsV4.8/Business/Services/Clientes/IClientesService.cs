using AspNetWebFormsV4._8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWebFormsV4._8.Business.Services.Clientes
{
    public interface IClientesService
    {
        Task<IEnumerable<TblClientes>> GetAllClientesAsync();
        Task<TblClientes> GetClienteByIdAsync(int id);
        Task AddClienteAsync(TblClientes cliente);
        Task UpdateClienteAsync(TblClientes cliente);
        Task DeleteClienteAsync(int id);
    }
}
