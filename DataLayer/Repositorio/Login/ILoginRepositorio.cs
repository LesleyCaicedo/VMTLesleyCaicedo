using EntityLayer.DTO;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositorio.Login
{
    public interface ILoginRepositorio
    {
        public Task<Usuario?> LoginUsuario(string username, string password);
    }
}
