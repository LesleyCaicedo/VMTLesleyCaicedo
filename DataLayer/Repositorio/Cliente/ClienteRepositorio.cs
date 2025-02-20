using EntityLayer.DTO;
using EntityLayer.Models;
using EntityLayer.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataLayer.Repositorio.Cliente
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        Response response = new();

        private readonly VmtlesleyCaicedoContext _context;

        public ClienteRepositorio(VmtlesleyCaicedoContext context)
        {
            _context = context;
        }

        public async Task<Response> RegistroCliente(ClienteDTO clienteDTO)
        {
            try
            {
                // Validaciones
                if (!Regex.IsMatch(clienteDTO.Identification, @"^\d{10,13}$"))
                {
                    return new Response { Code = ResponseType.Error, Message = "La identificación debe tener entre 10 y 13 dígitos y solo números." };
                }
                bool identificacionExistente = await _context.Clients
                    .AnyAsync(c => c.Identification == clienteDTO.Identification && c.Clientid != clienteDTO.Clientid);

                if (identificacionExistente)
                {
                    return new Response { Code = ResponseType.Error, Message = "La identificación ya está registrada en otro cliente" };
                }

                if (clienteDTO.Address.Length < 20 || clienteDTO.Address.Length > 100)
                {
                    return new Response { Code = ResponseType.Error, Message = "La dirección debe tener entre 20 y 100 caracteres." };
                }

                if (clienteDTO.Referenceaddress.Length < 20 || clienteDTO.Referenceaddress.Length > 100)
                {
                    return new Response { Code = ResponseType.Error, Message = "La referencia de la dirección debe tener entre 20 y 100 caracteres." };
                }

                if (!Regex.IsMatch(clienteDTO.Phonenumber, @"^09\d{8}$"))
                {
                    return new Response { Code = ResponseType.Error, Message = "El número de teléfono debe tener 10 dígitos, solo números y empezar con 09." };
                }

                Client nuevoCliente = new Client()
                {
                    Clientid = clienteDTO.Clientid,
                    Name = clienteDTO.Name,
                    Lastname = clienteDTO.Lastname,
                    Identification = clienteDTO.Identification,
                    Email = clienteDTO.Email,
                    Phonenumber = clienteDTO.Phonenumber,
                    Address = clienteDTO.Address,
                    Referenceaddress = clienteDTO.Referenceaddress,
                };

                await _context.Clients.AddAsync(nuevoCliente);
                await _context.SaveChangesAsync();

                return new Response { Code = ResponseType.Success, Message = "Cliente Registrado Exitosamente", Data = clienteDTO };
            }
            catch (Exception ex)
            {
                return new Response { Code = ResponseType.Error, Message = "Error al registrar cliente", Data = ex.Message };
            }
        }

        public async Task<Response> ActualizarCliente(ClienteDTO clienteDTO)
        {
            try
            {
                Client cliente = await _context.Clients.FindAsync(clienteDTO.Clientid);
                if (cliente == null)
                {
                    return new Response { Code = ResponseType.Error, Message = "Cliente no encontrado" };
                }

                // Validar identificación
                if (!Regex.IsMatch(clienteDTO.Identification, @"^\d{10,13}$"))
                {
                    return new Response { Code = ResponseType.Error, Message = "La identificación debe tener entre 10 y 13 dígitos y solo números." };
                }

                bool identificacionExistente = await _context.Clients
                    .AnyAsync(c => c.Identification == clienteDTO.Identification && c.Clientid != clienteDTO.Clientid);

                if (identificacionExistente)
                {
                    return new Response { Code = ResponseType.Error, Message = "La identificación ya está registrada en otro cliente" };
                }

                if (clienteDTO.Address.Length < 20 || clienteDTO.Address.Length > 100)
                {
                    return new Response { Code = ResponseType.Error, Message = "La dirección debe tener entre 20 y 100 caracteres." };
                }

                if (clienteDTO.Referenceaddress.Length < 20 || clienteDTO.Referenceaddress.Length > 100)
                {
                    return new Response { Code = ResponseType.Error, Message = "La referencia de la dirección debe tener entre 20 y 100 caracteres." };
                }

                if (!Regex.IsMatch(clienteDTO.Phonenumber, @"^09\d{8}$"))
                {
                    return new Response { Code = ResponseType.Error, Message = "El número de teléfono debe tener 10 dígitos, solo números y empezar con 09." };
                }

                // Actualización de los datos
                cliente.Name = clienteDTO.Name;
                cliente.Lastname = clienteDTO.Lastname;
                cliente.Identification = clienteDTO.Identification;
                cliente.Email = clienteDTO.Email;
                cliente.Phonenumber = clienteDTO.Phonenumber;
                cliente.Address = clienteDTO.Address;
                cliente.Referenceaddress = clienteDTO.Referenceaddress;

                await _context.SaveChangesAsync();
                return new Response { Code = ResponseType.Success, Message = "Cliente actualizado correctamente", Data = clienteDTO };
            }
            catch (Exception ex)
            {
                return new Response { Code = ResponseType.Error, Message = "No se pudo actualizar", Data = ex.Message };
            }
        }



    }
}
