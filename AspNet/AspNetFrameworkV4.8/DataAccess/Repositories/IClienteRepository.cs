using AspNetFrameworkV4._8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetFrameworkV4._8.DataAccess.Repositories
{
    public interface IClienteRepository
    {
        IEnumerable<TblClientes> GetAllClientes();
        TblClientes GetClienteById(int id);
        void AddCliente(TblClientes cliente);
        void UpdateCliente(TblClientes cliente);
        void DeleteCliente(int id);
    }
}
