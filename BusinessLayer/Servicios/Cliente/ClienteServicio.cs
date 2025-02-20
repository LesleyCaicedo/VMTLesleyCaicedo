using DataLayer.Repositorio.Cliente;
using EntityLayer.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Servicios.Cliente
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        Response response = new Response();

        public ClienteServicio(IClienteRepositorio repositorio)
        {
            _clienteRepositorio = repositorio;
        }

        public async Task<Response> RegistroCliente(ClienteDTO ClienteDTO)
        {
            response = await _clienteRepositorio.RegistroCliente(ClienteDTO);
            return response;
        }

        public async Task<Response> ActualizarCliente(ClienteDTO clienteDTO)
        {
            response = await _clienteRepositorio.ActualizarCliente(clienteDTO);
            return response;
        }

        public async Task<List<ClienteContratoDTO>> ObtenerClienteID(string indentificacion)
        {
            List<ClienteContratoDTO> cliente = await _clienteRepositorio.ObtenerClienteID(indentificacion);
            return cliente;
        }
    }
}
