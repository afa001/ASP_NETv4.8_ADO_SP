using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using AspNetFrameworkV4._8.Models;

namespace AspNetFrameworkV4._8.DataAccess.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<TblClientes> GetAllClientes()
        {
            var clientes = new List<TblClientes>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("GetAllClientes", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientes.Add(new TblClientes
                        {
                            Id = (int)reader["Id"],
                            RazonSocial = reader["RazonSocial"].ToString(),
                            IdTipoCliente = (int)reader["IdTipoCliente"],
                            FechaCreacion = (DateTime)reader["FechaCreacion"],
                            RFC = reader["RFC"].ToString()
                        });
                    }
                }
            }
            return clientes;
        }

        public TblClientes GetClienteById(int id)
        {
            TblClientes cliente = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("GetClienteById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cliente = new TblClientes
                        {
                            Id = (int)reader["Id"],
                            RazonSocial = reader["RazonSocial"].ToString(),
                            IdTipoCliente = (int)reader["IdTipoCliente"],
                            FechaCreacion = (DateTime)reader["FechaCreacion"],
                            RFC = reader["RFC"].ToString()
                        };
                    }
                }
            }
            return cliente;
        }

        public void AddCliente(TblClientes cliente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("AddCliente", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@RazonSocial", cliente.RazonSocial);
                command.Parameters.AddWithValue("@IdTipoCliente", cliente.IdTipoCliente);
                command.Parameters.AddWithValue("@FechaCreacion", cliente.FechaCreacion);
                command.Parameters.AddWithValue("@RFC", cliente.RFC);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCliente(TblClientes cliente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("UpdateCliente", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", cliente.Id);
                command.Parameters.AddWithValue("@RazonSocial", cliente.RazonSocial);
                command.Parameters.AddWithValue("@IdTipoCliente", cliente.IdTipoCliente);
                command.Parameters.AddWithValue("@FechaCreacion", cliente.FechaCreacion);
                command.Parameters.AddWithValue("@RFC", cliente.RFC);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCliente(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("DeleteCliente", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}