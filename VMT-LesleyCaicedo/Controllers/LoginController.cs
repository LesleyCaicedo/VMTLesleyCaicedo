using BusinessLayer.Servicios.Login;
using EntityLayer.Responses;
using Microsoft.AspNetCore.Mvc;

namespace VMT_LesleyCaicedo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServicio _loginServicio;

        Response response = new();

        public LoginController(ILoginServicio servicio)
        {
            _loginServicio = servicio;
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                var usuario = await _loginServicio.LoginUsuario(username, password);

                if (usuario == null)
                {
                    return Unauthorized("Credenciales incorrectas");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error en el servidor: " + ex.Message);
            }
        }

    }
}
