using AspNetWebFormsV4._8.Business.Services.Clientes;
using AspNetWebFormsV4._8.DataAccess.Repositories;
using AspNetWebFormsV4._8.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AspNetWebFormsV4._8.Business.Clientes
{
    public class ClientesService : IClientesService
    {
        private readonly IRepository<TblClientes> _repository;

        public ClientesService(IRepository<TblClientes> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TblClientes>> GetAllClientesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TblClientes> GetClienteByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddClienteAsync(TblClientes cliente)
        {
            await _repository.AddAsync(cliente);
        }

        public async Task UpdateClienteAsync(TblClientes cliente)
        {
            await _repository.UpdateAsync(cliente);
        }

        public async Task DeleteClienteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}