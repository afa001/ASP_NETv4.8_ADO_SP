using AspNetFrameworkV4._8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetFrameworkV4._8.DataAccess.Repositories
{
    public interface ITipoClienteRepository
    {
        IEnumerable<CatTipoCliente> GetAllTiposCliente();
        CatTipoCliente GetTipoClienteById(int id);
    }
}
