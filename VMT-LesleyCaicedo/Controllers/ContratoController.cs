using BusinessLayer.Servicios.Contratos;
using EntityLayer.DTO;
using EntityLayer.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VMT_LesleyCaicedo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly IContratoServicio _ContratoServicio;

        Response response = new();

        public ContratoController(IContratoServicio servicio)
        {
            _ContratoServicio = servicio;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RegistroContrato(ContratoDTO ContratoDTO)
        {
            response = await _ContratoServicio.RegistrarContrato(ContratoDTO);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ActualizarContrato(ContratoDTO ContratoDTO)
        {
            response = await _ContratoServicio.ActualizarContrato(ContratoDTO);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RegistrarContratoEstado(ContratoEstadoDTO contratoEstadoDTO)
        {
            response = await _ContratoServicio.RegistrarContratoEstado(contratoEstadoDTO);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ActualizarContratoEstado(ContratoEstadoDTO contratoEstadoDTO)
        {
            response = await _ContratoServicio.ActualizarContratoEstado(contratoEstadoDTO);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RegistrarFormaPago(FormaPagoDTO formaPagoDTO)
        {
            response = await _ContratoServicio.RegistrarFormaPago(formaPagoDTO);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ActualizarFormaPago(FormaPagoDTO formaPagoDTO)
        {
            response = await _ContratoServicio.ActualizarFormaPago(formaPagoDTO);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
