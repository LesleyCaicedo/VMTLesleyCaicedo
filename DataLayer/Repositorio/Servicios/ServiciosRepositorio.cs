using EntityLayer.DTO;
using EntityLayer.Models;
using EntityLayer.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositorio.Servicios
{
    public class ServiciosRepositorio : IServiciosRepositorio
    {
        Response response = new();

        private readonly VmtlesleyCaicedoContext _context;

        public ServiciosRepositorio(VmtlesleyCaicedoContext context)
        {
            _context = context;
        }

        public async Task<Response> RegistrarServicio(ServiciosDTO serviciosDTO)
        {
            try
            {
                Servicio nuevoServicio = new Servicio()
                {
                    Serviceid = serviciosDTO.Serviceid,
                    Servicename = serviciosDTO.Servicename,
                    Servicedescription = serviciosDTO.Servicedescription,
                    Price = serviciosDTO.Price
                };

                await _context.Servicios.AddAsync(nuevoServicio);
                await _context.SaveChangesAsync();

                response.Code = ResponseType.Success;
                response.Message = "Servicio registrado";
                response.Data = serviciosDTO;

                return response;
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "Error al registrar servicio";
                response.Data = ex.Message;

                return response;
            }
        }

        public async Task<Response> ActualizarServicio(ServiciosDTO serviciosDTO)
        {
            try
            {
                Servicio servicio = await _context.Servicios.FindAsync(serviciosDTO.Serviceid);

                servicio.Servicename = string.IsNullOrEmpty(serviciosDTO.Servicename) ? servicio.Servicename : serviciosDTO.Servicename;
                servicio.Servicedescription = string.IsNullOrEmpty(serviciosDTO.Servicedescription) ? servicio.Servicedescription : serviciosDTO.Servicedescription;
                servicio.Price = string.IsNullOrEmpty(serviciosDTO.Price) ? servicio.Price : serviciosDTO.Price;

                await _context.SaveChangesAsync();

                response.Code = ResponseType.Success;
                response.Message = "Servicio actualizado correctamente";
                response.Data = serviciosDTO;
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "Error al actualizar servicio";
                response.Data = ex.Message;
            }

            return response;
        }

    }
}
