using EntityLayer.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositorio.Usuarios
{
    public interface IUsuarioRepositorio
    {
        public Task<Response> RegistroUsuario(UsuarioDTO usuarioDTO);
    }
}
