using DataLayer.Repositorio.Contratos;
using DataLayer.Repositorio.Login;
using EntityLayer.DTO;
using EntityLayer.Mappers;
using EntityLayer.Models;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Servicios.Login
{
    public class LoginServicio : ILoginServicio
    {
        private readonly ILoginRepositorio _loginRepositorio;

        Response response = new Response();

        public LoginServicio(ILoginRepositorio repositorio)
        {
            _loginRepositorio = repositorio;
        }

        public async Task<Usuario?> LoginUsuario(string username, string password)
        {
            var usuario = await _loginRepositorio.LoginUsuario(username, password);
            return usuario;
        }

    }
}
