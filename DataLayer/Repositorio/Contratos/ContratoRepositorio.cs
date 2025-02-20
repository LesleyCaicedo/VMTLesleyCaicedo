using EntityLayer.DTO;
using EntityLayer.Models;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositorio.Contratos
{
    public class ContratoRepositorio : IContratoRepositorio
    {
        Response response = new();

        private readonly VmtlesleyCaicedoContext _context;

        public ContratoRepositorio(VmtlesleyCaicedoContext context)
        {
            _context = context;
        }

        public async Task<Response> RegistrarContrato(ContratoDTO contratoDTO)
        {
            try
            {
                Contract nuevoContrato = new Contract()
                {
                    Contractid = contratoDTO.Contractid,
                    Startdate = contratoDTO.Startdate,
                    Enddate = contratoDTO.Enddate,
                    ServiceServiceid = contratoDTO.ServiceServiceid,
                    StatuscontactStatusid = contratoDTO.StatuscontactStatusid,
                    ClientClientid = contratoDTO.ClientClientid,
                    MethodpaymentMethodpaymentid = contratoDTO.MethodpaymentMethodpaymentid
                };

                await _context.Contracts.AddAsync(nuevoContrato);
                await _context.SaveChangesAsync();

                response.Code = ResponseType.Success;
                response.Message = "Contrato Registrado";
                response.Data = contratoDTO;

                return response;
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "Error al registrar contrato";
                response.Data = ex.Message;

                return response;
            }
        }


        public async Task<Response> ActualizarContrato(ContratoDTO contratoDTO)
        {
            try
            {
                Contract contrato = await _context.Contracts.FindAsync(contratoDTO.Contractid);

                contrato.Startdate = contratoDTO.Startdate ?? contrato.Startdate;
                contrato.Enddate = contratoDTO.Enddate ?? contrato.Enddate;
                contrato.ServiceServiceid = contratoDTO.ServiceServiceid ?? contrato.ServiceServiceid;
                contrato.StatuscontactStatusid = contratoDTO.StatuscontactStatusid ?? contrato.StatuscontactStatusid;
                contrato.ClientClientid = contratoDTO.ClientClientid ?? contrato.ClientClientid;
                contrato.MethodpaymentMethodpaymentid = contratoDTO.MethodpaymentMethodpaymentid ?? contrato.MethodpaymentMethodpaymentid;

                await _context.SaveChangesAsync();

                response.Code = ResponseType.Success;
                response.Message = "Contrato Actualizado correctamente";
                response.Data = contratoDTO;
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "No se pudo Actualizar";
                response.Data = ex.Data;
            }

            return response;
        }

        public async Task<Response> RegistrarContratoEstado(ContratoEstadoDTO contratoEstadoDTO)
        {
            try
            {
                Statuscontract nuevoContratoEstado = new Statuscontract()
                {
                    Statusid = contratoEstadoDTO.Statusid,
                    Description = contratoEstadoDTO.Description
                };

                await _context.Statuscontracts.AddAsync(nuevoContratoEstado);
                await _context.SaveChangesAsync();

                response.Code = ResponseType.Success;
                response.Message = "Estado del contrato registrado";
                response.Data = contratoEstadoDTO;

                return response;
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "Error al registrar estado del contrato";
                response.Data = ex.Message;

                return response;
            }
        }

        public async Task<Response> ActualizarContratoEstado(ContratoEstadoDTO contratoEstadoDTO)
        {
            try
            {
                Statuscontract contratoEstado = await _context.Statuscontracts.FindAsync(contratoEstadoDTO.Statusid);

                contratoEstado.Description = string.IsNullOrEmpty(contratoEstadoDTO.Description) ? contratoEstado.Description : contratoEstadoDTO.Description;

                await _context.SaveChangesAsync();

                response.Code = ResponseType.Success;
                response.Message = "Estado del contrato actualizado correctamente";
                response.Data = contratoEstadoDTO;
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "Error al actualizar estado del contrato";
                response.Data = ex.Message;
            }

            return response;
        }

        public async Task<Response> RegistrarFormaPago(FormaPagoDTO formaPagoDTO)
        {
            try
            {
                Methodpayment nuevaFormaPago = new Methodpayment()
                {
                    Methodpaymentid = formaPagoDTO.Methodpaymentid,
                    Description = formaPagoDTO.Description
                };

                await _context.Methodpayments.AddAsync(nuevaFormaPago);
                await _context.SaveChangesAsync();

                response.Code = ResponseType.Success;
                response.Message = "Forma de pago registrada";
                response.Data = formaPagoDTO;

                return response;
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "Error al registrar forma de pago";
                response.Data = ex.Message;

                return response;
            }
        }

        public async Task<Response> ActualizarFormaPago(FormaPagoDTO formaPagoDTO)
        {
            try
            {
                Methodpayment formaPago = await _context.Methodpayments.FindAsync(formaPagoDTO.Methodpaymentid);

                formaPago.Description = string.IsNullOrEmpty(formaPagoDTO.Description) ? formaPago.Description : formaPagoDTO.Description;

                await _context.SaveChangesAsync();

                response.Code = ResponseType.Success;
                response.Message = "Forma de pago actualizada correctamente";
                response.Data = formaPagoDTO;
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "Error al actualizar forma de pago";
                response.Data = ex.Message;
            }

            return response;
        }

    }
}
