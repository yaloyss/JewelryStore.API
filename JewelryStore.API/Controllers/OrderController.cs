using JewelryStore.BLL.DTOs.Order;
using JewelryStore.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JewelryStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderCreatedResponseDTO>> CreateOrder([FromBody] OrderCreateDTO orderDto)
        {
            try
            {
                var createdOrder = await orderService.CreateOrderAsync(orderDto);
                return CreatedAtAction(nameof(GetClientOrderHistory), new { clientId = orderDto.ClientId }, createdOrder);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while placing the order: {ex.Message}");
            }
        }

        [HttpGet("client/{clientId}")]
        public async Task<ActionResult<IEnumerable<ClientOrderHistoryDTO>>> GetClientOrderHistory(int clientId)
        {
            try
            {
                if (clientId <= 0)
                {
                    return BadRequest("Client ID must be greater than zero.");
                }

                var orders = await orderService.GetClientOrderHistoryAsync(clientId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while getting client order history: {ex.Message}");
            }
        }

        [HttpGet("admin/all")]
        public async Task<ActionResult<IEnumerable<AdminOrderHistoryDTO>>> GetAllOrdersHistory()
        {
            try
            {
                var orders = await orderService.GetAllOrdersHistoryAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while getting full order history: {ex.Message}");
            }
        }
    }
}
