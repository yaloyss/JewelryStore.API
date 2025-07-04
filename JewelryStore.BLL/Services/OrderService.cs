﻿using AutoMapper;
using JewelryStore.BLL.DTOs.Order;
using JewelryStore.BLL.Services.Interfaces;
using JewelryStore.DAL.Models;
using JewelryStore.DAL.UOW;

namespace JewelryStore.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
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
                EmployeeId = 1, //temporary default value
                OrderDate = DateTime.UtcNow
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
            return mapper.Map<IEnumerable<ClientOrderHistoryDTO>>(orders);
        }

        public async Task<IEnumerable<AdminOrderHistoryDTO>> GetAllOrdersHistoryAsync()
        {
            var orders = await unitOfWork.Orders.GetWithDetailsAsync();
            return mapper.Map<IEnumerable<AdminOrderHistoryDTO>>(orders);
        }
    }
}
