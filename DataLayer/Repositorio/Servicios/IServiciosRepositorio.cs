using EntityLayer.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositorio.Servicios
{
    public interface IServiciosRepositorio
    {
        public Task<Response> RegistrarServicio(ServiciosDTO serviciosDTO);
        public Task<Response> ActualizarServicio(ServiciosDTO serviciosDTO);

    }
}
