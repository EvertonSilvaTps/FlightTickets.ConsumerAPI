using Bogus;
using FlightTickets.Models.Models;

namespace FlightTickets.Tests.Models
{
    public class TicketModelTests
    {
        private Faker _faker = new Faker("pt_BR");

        [Fact]  // DataAnnotation
        public void TestandoConstrutordeTicketComTodosOsParametros()
        {
            //Arrange
            var passengerName = _faker.Name.FullName();  // gera name random (firstname + lastname)

            var flightNumber = _faker.Random.AlphaNumeric(6).ToUpper();  // Letras Maiusculas (Qtdd 6)

            var seatNumber = $"{_faker.Random.Int(1, 30)}{_faker.Random.Char('A', 'F')}";    //  Gera um numero e uma letra

            var price = _faker.Finance.Amount(600, 6000);


            //Act
            var ticket = new Ticket(passengerName, flightNumber, seatNumber, price);  // valida do objeto criado


            //Assert
            Assert.NotNull(ticket);  // Verifica se o objeto não é null

            // Verifica se os valores são iguais aos campos, respectivamente a ordem
            Assert.Equal(passengerName, ticket.PassengerName);
            Assert.Equal(flightNumber, ticket.FlightNumber);
            Assert.Equal(seatNumber, ticket.SeatNumber);
            Assert.Equal(price, ticket.Price);





        }
    }
}
