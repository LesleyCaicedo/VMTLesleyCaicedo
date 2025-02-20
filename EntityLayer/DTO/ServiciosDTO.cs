using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class ServiciosDTO
    {
        public int Serviceid { get; set; }

        public string? Servicename { get; set; }

        public string? Servicedescription { get; set; }

        public string? Price { get; set; }
    }
}
