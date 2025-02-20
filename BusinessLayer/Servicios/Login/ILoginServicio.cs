using EntityLayer.DTO;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Servicios.Login
{
    public interface ILoginServicio
    {
        public Task<Usuario?> LoginUsuario(string username, string password);
    }
}
