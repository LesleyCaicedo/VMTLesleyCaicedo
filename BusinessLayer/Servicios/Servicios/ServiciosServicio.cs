using DataLayer.Repositorio.Servicios;
using EntityLayer.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Servicios.Servicios
{
    public class ServiciosServicio : IServiciosServicio
    {
        private readonly IServiciosRepositorio _serviciosRepositorio;

        Response response = new Response();

        public ServiciosServicio(IServiciosRepositorio repositorio)
        {
            _serviciosRepositorio = repositorio;
        }

        public async Task<Response> RegistrarServicio(ServiciosDTO serviciosDTO)
        {
            response = await _serviciosRepositorio.RegistrarServicio(serviciosDTO);
            return response;
        }

        public async Task<Response> ActualizarServicio(ServiciosDTO serviciosDTO)
        {
            response = await _serviciosRepositorio.ActualizarServicio(serviciosDTO);
            return response;
        }
    }
}
