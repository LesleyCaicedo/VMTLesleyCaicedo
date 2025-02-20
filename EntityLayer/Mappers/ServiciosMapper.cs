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
    public partial class ServiciosMapper
    {
        public partial Servicio ServiciosToServiciosDTO(ServiciosDTO serviciosDTO);

        public partial ServiciosDTO ServiciosToServiciosDTO(Servicio servicios);
    }
}
