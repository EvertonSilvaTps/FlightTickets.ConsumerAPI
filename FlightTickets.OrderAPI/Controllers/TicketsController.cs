using FlightTickets.Models.DTOs;
using FlightTickets.OrderAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlightTickets.OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ILogger<TicketsController> _logger;
        private readonly ITicketService _ticketService;

        public TicketsController(ILogger<TicketsController> logger, ITicketService ticketService)
        {
            _logger = logger;
            _ticketService = ticketService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateTicketAsync([FromBody] TicketRequestDTO ticket)
        {
            _logger.LogInformation("Creating a new ticket.");

            var createdTicket = await _ticketService.CreateTicketAsync(ticket);

            return Ok(createdTicket);

            //return CreatedAtAction(nameof(GetTicketById), new { id = createdTicket.Id }, createdTicket);
        }


    }
}
