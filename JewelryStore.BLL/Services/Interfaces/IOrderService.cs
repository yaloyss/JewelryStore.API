using JewelryStore.BLL.DTOs.Order;

namespace JewelryStore.BLL.Services.Interfaces
{
	public interface IOrderService
	{
        Task<OrderCreatedResponseDTO> CreateOrderAsync(OrderCreateDTO orderDto);
        Task<IEnumerable<ClientOrderHistoryDTO>> GetClientOrderHistoryAsync(int clientId);
        Task<IEnumerable<AdminOrderHistoryDTO>> GetAllOrdersHistoryAsync();
    }
}

