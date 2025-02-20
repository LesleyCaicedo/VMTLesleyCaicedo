using EntityLayer.DTO;
using EntityLayer.Models;
using EntityLayer.Responses;
using Microsoft.EntityFrameworkCore;


namespace DataLayer.Repositorio.Usuarios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        Response response = new();

        private readonly VmtlesleyCaicedoContext _context;

        public UsuarioRepositorio(VmtlesleyCaicedoContext context)
        {
            _context = context;
        }

        public async Task<Response> RegistroUsuario(UsuarioDTO usuarioDTO)
        {
            try
            {
                // Validar el nombre de usuario
                if (usuarioDTO.Username.Length < 8 || usuarioDTO.Username.Length > 20)
                {
                    response.Code = ResponseType.Error;
                    response.Message = "El nombre de usuario debe tener entre 8 y 20 caracteres.";
                    return response;
                }

                if (!usuarioDTO.Username.Any(char.IsLetter) || !usuarioDTO.Username.Any(char.IsDigit))
                {
                    response.Code = ResponseType.Error;
                    response.Message = "El nombre de usuario debe tener letras y al menos un número.";
                    return response;
                }

                if (usuarioDTO.Username.Any(ch => !char.IsLetterOrDigit(ch)))
                {
                    response.Code = ResponseType.Error;
                    response.Message = "El nombre de usuario no debe contener caracteres especiales.";
                    return response;
                }

                // Verificar si el nombre de usuario ya existe en la base de datos
                var usuarioExistente = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Username == usuarioDTO.Username);
                if (usuarioExistente != null)
                {
                    response.Code = ResponseType.Error;
                    response.Message = "El nombre de usuario ya está registrado.";
                    return response;
                }

                // Validar la contraseña
                if (usuarioDTO.Password.Length < 8 || usuarioDTO.Password.Length > 30)
                {
                    response.Code = ResponseType.Error;
                    response.Message = "La contraseña debe tener entre 8 y 30 caracteres.";
                    return response;
                }

                if (!usuarioDTO.Password.Any(char.IsUpper) || !usuarioDTO.Password.Any(char.IsDigit))
                {
                    response.Code = ResponseType.Error;
                    response.Message = "La contraseña debe contener al menos una letra mayúscula y un número.";
                    return response;
                }

                // Crear el nuevo usuario
                Usuario nuevoUsuario = new Usuario()
                {
                    Userid = usuarioDTO.Userid,
                    Username = usuarioDTO.Username,
                    Email = usuarioDTO.Email,
                    Password = usuarioDTO.Password,
                    RolRolid = usuarioDTO.RolRolid,
                    Creationdate = usuarioDTO.Creationdate,
                    Usercreate = usuarioDTO.Usercreate,
                    Userapproval = usuarioDTO.Userapproval,
                    Datespproval = usuarioDTO.Datespproval,
                    UserstatusStatusid = usuarioDTO.UserstatusStatusid
                };

                await _context.Usuarios.AddAsync(nuevoUsuario);
                await _context.SaveChangesAsync();

                response.Code = ResponseType.Success;
                response.Message = "Usuario Registrado";
                response.Data = usuarioDTO;

                return response;
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "Error al registrar usuario";
                response.Data = ex.Message;

                return response;
            }
        }



    }
}
