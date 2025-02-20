using BusinessLayer.Servicios.Servicios;
using EntityLayer.DTO;
using EntityLayer.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VMT_LesleyCaicedo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly IServiciosServicio _serviciosServicio;

        Response response = new();

        public ServiciosController(IServiciosServicio servicio)
        {
            _serviciosServicio = servicio;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RegistroServicios(ServiciosDTO ServiciosDTO)
        {
            response = await _serviciosServicio.RegistrarServicio(ServiciosDTO);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ActualizarServicios(ServiciosDTO ServiciosDTO)
        {
            response = await _serviciosServicio.ActualizarServicio(ServiciosDTO);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
