using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class UsuarioDTO
    {
        public int Userid { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public int? RolRolid { get; set; }

        public DateTime? Creationdate { get; set; }

        public int? Usercreate { get; set; }

        public int? Userapproval { get; set; }

        public DateTime? Datespproval { get; set; }

        public int? UserstatusStatusid { get; set; }
    }
}
