using JewelryStore.BLL.DTOs.Client;

namespace JewelryStore.BLL.Services.Interfaces
{
	public interface IClientService
	{
        Task<ClientSummaryDTO?> GetClientByIdAsync(int clientId);
        Task<IEnumerable<ClientSummaryDTO>> GetAllClientsAsync();
    }
}

