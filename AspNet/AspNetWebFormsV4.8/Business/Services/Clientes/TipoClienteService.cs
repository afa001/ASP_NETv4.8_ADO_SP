using AspNetWebFormsV4._8.DataAccess.Repositories;
using AspNetWebFormsV4._8.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AspNetWebFormsV4._8.Business.Services.Clientes
{
    public class TipoClienteService : ITipoClienteService
    {
        private readonly IRepository<CatTipoCliente> _repository;

        public TipoClienteService(IRepository<CatTipoCliente> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CatTipoCliente>> GetAllTipoClientesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CatTipoCliente> GetTipoClienteByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}