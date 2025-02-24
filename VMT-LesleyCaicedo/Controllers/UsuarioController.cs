using BusinessLayer.Servicios.Usuarios;
using EntityLayer.DTO;
using EntityLayer.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VMT_LesleyCaicedo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;

        Response response = new();

        public UsuarioController(IUsuarioServicio servicio)
        {
            _usuarioServicio = servicio;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RegistroUsuario(UsuarioDTO usuarioDTO)
        {
            response = await _usuarioServicio.RegistroUsuario(usuarioDTO);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ObtenerUsuario()
        {
            response = await _usuarioServicio.ObtenerUsuarios();
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
