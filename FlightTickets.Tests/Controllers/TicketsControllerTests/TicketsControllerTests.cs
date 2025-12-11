using FlightTickets.Models.DTOs;
using FlightTickets.OrderAPI.Controllers;
using FlightTickets.OrderAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlightTickets.Tests.Controllers.TicketsControllerTests
{
    public class TicketsControllerTests
    {
        private ILogger<TicketsController> _logger;
        private TicketService _ticketService;
        private TicketsController _ticketsController;

        public TicketsControllerTests()
        {
            _logger = new LoggerFactory().CreateLogger<TicketsController>();
            _ticketService = new TicketService();
            _ticketsController = new TicketsController(_logger, _ticketService);
        }


        [Fact]
        public void ProcessTicketMustReturnOkResult()
        {
            //Arrange
            var ticket = new TicketRequestDTO{ PassengerName = "Nome para teste",
                                                FlightNumber = "FASGSD",
                                                SeatNumber = "5A",
                                                Price = 1500 };


            //Act
            var result = _ticketsController.CreateTicketAsync(ticket).Result;

            
            //Assert
            Assert.NotNull(result);  // verificar se o retorno não é nulo
            Assert.IsType<OkObjectResult>(result);  // verificar se o tipo do retorno é Result

        }


    }
}
