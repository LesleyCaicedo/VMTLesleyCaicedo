using BusinessLayer.Servicios.Cliente;
using EntityLayer.DTO;
using EntityLayer.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VMT_LesleyCaicedo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServicio _clienteServicio;

        Response response = new();

        public ClienteController(IClienteServicio servicio)
        {
            _clienteServicio = servicio;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RegistroCliente(ClienteDTO ClienteDTO)
        {
            response = await _clienteServicio.RegistroCliente(ClienteDTO);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ActualizarCliente(ClienteDTO ClienteDTO)
        {
            response = await _clienteServicio.ActualizarCliente(ClienteDTO);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ObtenerClienteID(string indentificacion)
        {
            try
            {
                List<ClienteContratoDTO> cliente = await _clienteServicio.ObtenerClienteID(indentificacion);

                if (cliente == null)
                {
                    return Unauthorized("No hay contratos vinculados al cliente");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error en el servidor: " + ex.Message);
            }
        }
    }
}
