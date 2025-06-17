using JewelryStore.BLL.DTOs.Client;
using JewelryStore.BLL.DTOs.Order;
using JewelryStore.DAL.Models;
using JewelryStore.DAL.Repositories.Interfaces;
using JewelryStore.DAL.UOW;

namespace JewelryStore.BLL.Services
{
    public class OrderService
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<OrderCreatedResponseDTO> CreateOrderAsync(OrderCreateDTO orderDto)
        {
            var product = await unitOfWork.Products.GetByIdAsync(orderDto.ProductId);
            var client = await unitOfWork.Clients.GetByIdAsync(orderDto.ClientId);

            if (product == null)
                throw new ArgumentException($"Product with ID {orderDto.ProductId} not found");

            if (client == null)
                throw new ArgumentException($"Client with ID {orderDto.ClientId} not found");

            var order = new Order
            {
                ProductId = orderDto.ProductId,
                ClientId = orderDto.ClientId,
                OrderDate = DateTime.Now
            };

            await unitOfWork.Orders.AddAsync(order);
            await unitOfWork.SaveChangesAsync();

            return new OrderCreatedResponseDTO
            {
                OrderId = order.OrderId,
                ProductId = product.ProductId,
                ProductName = product.Name,
                ProductPrice = product.Price,
                ClientName = $"{client.FirstName} {client.LastName}",
                OrderDate = order.OrderDate
            };
        }

        public async Task<IEnumerable<ClientOrderHistoryDTO>> GetClientOrderHistoryAsync(int clientId)
        {
            var orders = await unitOfWork.Orders.GetByClientIdAsync(clientId);

            return orders.Select(o => new ClientOrderHistoryDTO
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                ProductName = o.Product.Name,
                ProductPrice = o.Product.Price
            });
        }

        public async Task<IEnumerable<AdminOrderHistoryDTO>> GetAllOrdersHistoryAsync()
        {
            var orders = await unitOfWork.Orders.GetWithDetailsAsync();

            return orders.Select(o => new AdminOrderHistoryDTO
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                ProductName = o.Product.Name,
                ProductPrice = o.Product.Price,
                Client = new ClientSummaryDTO
                {
                    ClientId = o.Client.ClientId,
                    FirstName = o.Client.FirstName,
                    LastName = o.Client.LastName,
                    PhoneNumber = o.Client.PhoneNumber
                }
            });
        }
    }
}
