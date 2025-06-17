using AutoMapper;
using JewelryStore.BLL.DTOs.Client;
using JewelryStore.BLL.Services.Interfaces;
using JewelryStore.DAL.UOW;

namespace JewelryStore.BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ClientSummaryDTO?> GetClientByIdAsync(int clientId)
        {
            var client = await unitOfWork.Clients.GetByIdAsync(clientId);
            return client == null ? null : mapper.Map<ClientSummaryDTO>(client);
        }

        public async Task<IEnumerable<ClientSummaryDTO>> GetAllClientsAsync()
        {
            var clients = await unitOfWork.Clients.GetAllAsync();
            return mapper.Map<IEnumerable<ClientSummaryDTO>>(clients);
        }
    }
}
