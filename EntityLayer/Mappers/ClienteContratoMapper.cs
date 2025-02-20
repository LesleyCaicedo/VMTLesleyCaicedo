using EntityLayer.DTO;
using EntityLayer.Models;
using Riok.Mapperly.Abstractions;
using System.Collections.Generic;

namespace EntityLayer.Mappers
{
    [Mapper]
    public partial class ClienteContratoMapper
    {
        public partial Client ClienteContratoDTOToCliente(ClienteContratoDTO clienteContratoDTO);
        public partial ClienteContratoDTO ClienteToClienteContratoDTO(Client cliente);

        // Mapeo de listas correctamente definido
        public partial List<ClienteContratoDTO> ListaClienteToClienteContratoDTO(List<Client> clients);
    }
}
