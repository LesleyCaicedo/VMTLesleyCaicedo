using DataLayer.Helper;
using EntityLayer.DTO;
using EntityLayer.Mappers;
using EntityLayer.Models;
using EntityLayer.Responses;
using Microsoft.EntityFrameworkCore;


namespace DataLayer.Repositorio.Usuarios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        Response response = new();

        private readonly VmtlesleyCaicedoContext _context;
        private readonly UsuarioMapper _mapperUser = new();
        private readonly RolMapper _mapperRol = new();

        public UsuarioRepositorio(VmtlesleyCaicedoContext context)
        {
            _context = context;
        }

        public async Task<Response> RegistroUsuario(UsuarioDTO usuarioDTO)
        {
            try
            {
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

                var usuarioExistente = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Username == usuarioDTO.Username);
                if (usuarioExistente != null)
                {
                    response.Code = ResponseType.Error;
                    response.Message = "El nombre de usuario ya está registrado.";
                    return response;
                }

                //// Validar la contraseña
                //if (usuarioDTO.Password.Length < 8 || usuarioDTO.Password.Length > 30)
                //{
                //    response.Code = ResponseType.Error;
                //    response.Message = "La contraseña debe tener entre 8 y 30 caracteres.";
                //    return response;
                //}

                //if (!usuarioDTO.Password.Any(char.IsUpper) || !usuarioDTO.Password.Any(char.IsDigit))
                //{
                //    response.Code = ResponseType.Error;
                //    response.Message = "La contraseña debe contener al menos una letra mayúscula y un número.";
                //    return response;
                //}

                Usuario nuevoUsuario = new Usuario()
                {
                    Userid = usuarioDTO.Userid,
                    Username = usuarioDTO.Username,
                    Email = usuarioDTO.Email,
                    Password = CuentaHelper.GenerarContraseña(),
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

        public async Task<Response> ObtenerUsuarios()
        {
            try
            {
                List<UsuarioDTO> usuarios = _mapperUser.UsuariosToUsuariosDTO(await _context.Usuarios.ToListAsync());
                List<RolDTO> roles = _mapperRol.RolesToRolesDTO(await _context.Rols.ToListAsync());

                var usuariosConRol = from usuario in usuarios
                                     join rol in roles
                                     on usuario.RolRolid equals rol.Rolid into rolJoin
                                     from rol in rolJoin.DefaultIfEmpty()

                                     join creador in usuarios
                                     on usuario.Usercreate equals creador.Userid into creadorJoin
                                     from creador in creadorJoin.DefaultIfEmpty()

                                     select new
                                     {
                                         usuario.Userid,
                                         usuario.Username,
                                         usuario.Email,
                                         usuario.UserstatusStatusid,
                                         RolNombre = rol != null ? rol.Rolname : "Sin rol asignado",
                                         CreadorNombre = creador != null ? creador.Username : "Sistema" // Si no hay creador
                                     };

                // Devolver respuesta exitosa
                response.Code = ResponseType.Success;
                response.Message = "Usuarios con roles encontrados";
                response.Data = usuariosConRol.ToList();

            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "Error al registrar usuario";
                response.Data = ex.Message;
            }
            return response;
        }
    }
}
