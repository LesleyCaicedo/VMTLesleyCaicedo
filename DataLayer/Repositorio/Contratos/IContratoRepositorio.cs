using EntityLayer.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositorio.Contratos
{
    public interface IContratoRepositorio
    {
        public Task<Response> RegistrarContrato(ContratoDTO contratoDTO);
        public Task<Response> ActualizarContrato(ContratoDTO contratoDTO);

        public Task<Response> RegistrarContratoEstado(ContratoEstadoDTO contratoEstadoDTO);
        public Task<Response> ActualizarContratoEstado(ContratoEstadoDTO contratoEstadoDTO);

        public Task<Response> RegistrarFormaPago(FormaPagoDTO formaPagoDTO);
        public Task<Response> ActualizarFormaPago(FormaPagoDTO formaPagoDTO);
    }
}
