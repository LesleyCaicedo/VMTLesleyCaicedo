using EntityLayer.DTO;
using EntityLayer.Mappers;
using EntityLayer.Models;
using EntityLayer.Responses;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositorio.Login
{
    public class LoginRepositorio : ILoginRepositorio
    {
        Response response = new();

        private readonly VmtlesleyCaicedoContext _context;

        public LoginRepositorio(VmtlesleyCaicedoContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> LoginUsuario(string username, string password)
        {
            try
            {
                var usuario = _context.Usuarios
                    .FromSqlRaw("EXEC SP_LoginUsuario @Username, @Password",
                                new SqlParameter("@Username", username),
                                new SqlParameter("@Password", password))
                    .AsEnumerable() 
                    .Select(u => new Usuario
                    {
                        Userid = u.Userid,
                        Username = u.Username,
                        Email = u.Email,
                        RolRolid = u.RolRolid
                    })
                    .FirstOrDefault();

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el procedimiento almacenado", ex);
            }
        }


    }
}
