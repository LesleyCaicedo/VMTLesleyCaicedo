using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class ClienteContratoDTO
    {
        public string? Name { get; set; }

        public string? Lastname { get; set; }

        public string? Identification { get; set; }

        public string? Email { get; set; }

        public string? Phonenumber { get; set; }

        public string? Address { get; set; }
        public int? contractid { get; set; }

        public DateTime? Startdate { get; set; }

        public DateTime? Enddate { get; set; }

        public string? Servicename { get; set; }

        public string? Price { get; set; }

        public string? FormaPago { get; set; }

        public string? EstadoContrato { get; set; }
    }
}
