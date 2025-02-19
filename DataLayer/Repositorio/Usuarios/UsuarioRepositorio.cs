using EntityLayer.DTO;
using EntityLayer.Models;
using EntityLayer.Responses;


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
