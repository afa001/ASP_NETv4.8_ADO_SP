﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetFrameworkV4._8.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public int IdTipoCliente { get; set; }
        public string NombreTipoCliente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string RFC { get; set; }
    }
}