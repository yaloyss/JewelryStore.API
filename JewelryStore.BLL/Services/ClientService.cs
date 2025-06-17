using JewelryStore.BLL.DTOs.Client;
using JewelryStore.DAL.UOW;

namespace JewelryStore.BLL.Services
{
    public class ClientService
    {
        private readonly IUnitOfWork unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ClientSummaryDTO?> GetClientByIdAsync(int clientId)
        {
            var client = await unitOfWork.Clients.GetByIdAsync(clientId);

            if (client == null)
                return null;

            return new ClientSummaryDTO
            {
                ClientId = client.ClientId,
                FirstName = client.FirstName,
                LastName = client.LastName,
                PhoneNumber = client.PhoneNumber
            };
        }

        public async Task<IEnumerable<ClientSummaryDTO>> GetAllClientsAsync()
        {
            var clients = await unitOfWork.Clients.GetAllAsync();

            return clients.Select(c => new ClientSummaryDTO
            {
                ClientId = c.ClientId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber
            });
        }
    }
}
