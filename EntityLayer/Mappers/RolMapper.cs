using EntityLayer.DTO;
using EntityLayer.Models;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Mappers
{
    [Mapper]
    public partial class RolMapper
    {
        public partial Rol RolToRolDTO(RolDTO rolDTO);
        public partial RolDTO RolToRolDTO(Rol rol);
        public partial List<RolDTO> RolesToRolesDTO(List<Rol> roles);
    }
}
