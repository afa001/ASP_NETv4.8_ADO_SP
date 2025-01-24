using AspNetWebFormsV4._8.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;

namespace AspNetWebFormsV4._8.DataAccess.Repositories
{
    public class ClientesRepository : IRepository<TblClientes>
    {
        private readonly string _connectionString;

        public ClientesRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
        }

        public async Task<IEnumerable<TblClientes>> GetAllAsync()
        {
            var clientes = new List<TblClientes>();
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("GetAllClientes", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        clientes.Add(new TblClientes
                        {
                            Id = reader.GetInt32(0),
                            RazonSocial = reader.GetString(1),
                            IdTipoCliente = reader.GetInt32(2),
                            FechaCreacion = reader.GetDateTime(3),
                            RFC = reader.GetString(4)            
                        });
                    }
                }
            }
            return clientes;
        }

        public async Task<TblClientes> GetByIdAsync(int id)
        {
            TblClientes cliente = null;
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("GetClienteById", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        cliente = new TblClientes
                        {
                            Id = reader.GetInt32(0),
                            RazonSocial = reader.GetString(1),
                            IdTipoCliente = reader.GetInt32(2),
                            FechaCreacion = reader.GetDateTime(3),
                            RFC = reader.GetString(4)
                        };
                    }
                }
            }
            return cliente;
        }

        public async Task AddAsync(TblClientes entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("AddCliente", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RazonSocial", entity.RazonSocial);
                command.Parameters.AddWithValue("@IdTipoCliente", entity.IdTipoCliente);
                command.Parameters.AddWithValue("@FechaCreacion", entity.FechaCreacion);
                command.Parameters.AddWithValue("@RFC", entity.RFC);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateAsync(TblClientes entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("UpdateCliente", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", entity.Id);
                command.Parameters.AddWithValue("@RazonSocial", entity.RazonSocial);
                command.Parameters.AddWithValue("@IdTipoCliente", entity.IdTipoCliente);
                command.Parameters.AddWithValue("@FechaCreacion", entity.FechaCreacion);
                command.Parameters.AddWithValue("@RFC", entity.RFC);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("DeleteCliente", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

    }
}