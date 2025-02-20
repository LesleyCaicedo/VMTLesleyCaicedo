using EntityLayer.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Servicios.Servicios
{
    public interface IServiciosServicio
    {
        public Task<Response> ActualizarServicio(ServiciosDTO serviciosDTO);
        public Task<Response> RegistrarServicio(ServiciosDTO serviciosDTO);
    }
}
