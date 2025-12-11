using FlightTickets.Models.DTOs;
using FlightTickets.OrderAPI.Services;

namespace FlightTickets.Tests.Services.TicketServiceTests
{
    public class TicketServiceTests
    {
        private TicketService _ticketService;

        public TicketServiceTests()
        {
            _ticketService = new TicketService();
        }


        [Fact]
        public async Task ProcessPublishFromQueueAndReturnDTO()
        {



            // Arrange
            var ticket = new TicketRequestDTO
            {
                PassengerName = "Nome para teste",
                FlightNumber = "FASGSD",
                SeatNumber = "5A",
                Price = 1500
            };


            // Act
            var result = await _ticketService.CreateTicketAsync(ticket);


            // Assert
            Assert.NotNull(result);
            Assert.IsType<TicketResponseDTO>(result);

            Assert.False(string.IsNullOrEmpty(result.Id));
            Assert.Equal(ticket.PassengerName, result.PassengerName);
            Assert.Equal(ticket.FlightNumber, result.FlightNumber);
            Assert.Equal(ticket.SeatNumber, result.SeatNumber);
            Assert.Equal(ticket.Price, result.Price);


        }






    }
}
