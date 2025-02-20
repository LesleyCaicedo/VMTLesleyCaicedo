using DataLayer.Repositorio.Contratos;
using EntityLayer.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Servicios.Contratos
{
    public class ContratoServicio : IContratoServicio
    {
        private readonly IContratoRepositorio _ContratoRepositorio;

        Response response = new Response();

        public ContratoServicio(IContratoRepositorio repositorio)
        {
            _ContratoRepositorio = repositorio;
        }

        public async Task<Response> RegistrarContrato(ContratoDTO contratoDTO)
        {
            response = await _ContratoRepositorio.RegistrarContrato(contratoDTO);
            return response;
        }

        public async Task<Response> ActualizarContrato(ContratoDTO contratoDTO)
        {
            response = await _ContratoRepositorio.ActualizarContrato(contratoDTO);
            return response;
        }

        public async Task<Response> RegistrarContratoEstado(ContratoEstadoDTO contratoEstadoDTO)
        {
            response = await _ContratoRepositorio.RegistrarContratoEstado(contratoEstadoDTO);
            return response;
        }
        public async Task<Response> ActualizarContratoEstado(ContratoEstadoDTO contratoEstadoDTO)
        {
            response = await _ContratoRepositorio.ActualizarContratoEstado(contratoEstadoDTO);
            return response;
        }

        public async Task<Response> RegistrarFormaPago(FormaPagoDTO formaPagoDTO)
        {
            response = await _ContratoRepositorio.RegistrarFormaPago(formaPagoDTO);
            return response;
        }
        public async Task<Response> ActualizarFormaPago(FormaPagoDTO formaPagoDTO)
        {
            response = await _ContratoRepositorio.ActualizarFormaPago(formaPagoDTO);
            return response;
        }

    }
}
