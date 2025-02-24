using DataLayer.Repositorio.Usuarios;
using EntityLayer.DTO;
using EntityLayer.Responses;

namespace BusinessLayer.Servicios.Usuarios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        Response response = new Response();

        public UsuarioServicio(IUsuarioRepositorio repositorio)
        {
            _usuarioRepositorio = repositorio;
        }

        public async Task<Response> RegistroUsuario(UsuarioDTO usuarioDTO)
        {
            response = await _usuarioRepositorio.RegistroUsuario(usuarioDTO);
            return response;
        }

        public async Task<Response> ObtenerUsuarios()
        {
            response = await _usuarioRepositorio.ObtenerUsuarios();
            return response;
        }
    }
}
