using AspNetWebFormsV4._8.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AspNetWebFormsV4._8.DataAccess.Repositories
{
    public class TipoClienteRepository : IRepository<CatTipoCliente>
    {
        private readonly string _connectionString;

        public TipoClienteRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
        }

        public Task AddAsync(CatTipoCliente entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CatTipoCliente>> GetAllAsync()
        {
            var tipoClientes = new List<CatTipoCliente>();
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("GetAlltiposCliente", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        tipoClientes.Add(new CatTipoCliente
                        {
                            Id = reader.GetInt32(0),
                            TipoCliente = reader.GetString(1)
                        });
                    }
                }
            }
            return tipoClientes;
        }

        public async Task<CatTipoCliente> GetByIdAsync(int id)
        {
            CatTipoCliente tipoClientes = null;
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("GetTipoClienteById", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        tipoClientes = new CatTipoCliente
                        {
                            Id = reader.GetInt32(0),
                            TipoCliente = reader.GetString(1)
                        };
                    }
                }
            }
            return tipoClientes;
        }

        public Task UpdateAsync(CatTipoCliente entity)
        {
            throw new NotImplementedException();
        }
    }
}