using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class ClienteDTO
    {
        public int Clientid { get; set; }

        public string? Name { get; set; }

        public string? Lastname { get; set; }

        public string? Identification { get; set; }

        public string? Email { get; set; }

        public string? Phonenumber { get; set; }

        public string? Address { get; set; }

        public string? Referenceaddress { get; set; }
    }
}
