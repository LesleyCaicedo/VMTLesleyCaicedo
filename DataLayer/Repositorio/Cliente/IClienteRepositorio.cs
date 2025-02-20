using EntityLayer.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositorio.Cliente
{
    public interface IClienteRepositorio
    {
        public Task<Response> RegistroCliente(ClienteDTO clienteDTO);
        public Task<Response> ActualizarCliente(ClienteDTO clienteDTO);
    }
}
