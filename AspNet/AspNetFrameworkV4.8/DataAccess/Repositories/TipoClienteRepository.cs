using AspNetFrameworkV4._8.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetFrameworkV4._8.DataAccess.Repositories
{
    public class TipoClienteRepository : ITipoClienteRepository
    {
        private readonly string _connectionString;

        public TipoClienteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<CatTipoCliente> GetAllTiposCliente()
        {
            var tiposCliente = new List<CatTipoCliente>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("GetAllTiposCliente", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tiposCliente.Add(new CatTipoCliente
                        {
                            Id = (int)reader["Id"],
                            TipoCliente = reader["TipoCliente"].ToString()
                        });
                    }
                }
            }
            return tiposCliente;
        }

        public CatTipoCliente GetTipoClienteById(int id)
        {
            CatTipoCliente tipoCliente = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("GetTipoClienteById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tipoCliente = new CatTipoCliente
                        {
                            Id = (int)reader["Id"],
                            TipoCliente = reader["TipoCliente"].ToString()
                        };
                    }
                }
            }
            return tipoCliente;
        }
    }
}