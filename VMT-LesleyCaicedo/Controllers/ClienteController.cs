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
    }
}
