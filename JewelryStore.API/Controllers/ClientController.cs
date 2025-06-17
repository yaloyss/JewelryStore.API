using JewelryStore.BLL.DTOs.Client;
using JewelryStore.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JewelryStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientSummaryDTO>>> GetAllClients()
        {
            try
            {
                var clients = await clientService.GetAllClientsAsync();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while getting clients list: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientSummaryDTO>> GetClientById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Client ID must be greater than zero.");
                }

                var client = await clientService.GetClientByIdAsync(id);

                if (client == null)
                {
                    return NotFound($"Client with ID {id} is not found.");
                }

                return Ok(client);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while getting a client: {ex.Message}");
            }
        }
    }
}

