using FlightTickets.Models.Models;
using System.Text;
using System.Text.Json;

namespace FlightTickets.Tests.Services.PaymentServiceTests
{
    public class PaymentServiceTests
    {
        [Fact]
        public void ProcessReceivedFromQueue()
        {
            //Arrange
            var ticketAux = new Ticket("Nome para teste", "FASGSD", "5A", 1500);

            var json = JsonSerializer.Serialize(ticketAux); // Serializar o objetc para Json

            var bytes = Encoding.UTF8.GetBytes(json);  // convertê-lo para array bytes
            var auxMemory = new ReadOnlyMemory<byte>(bytes);

            //Act
            var body = auxMemory.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var ticket = JsonSerializer.Deserialize<Ticket>(message);

            //Assert
            Assert.IsType<byte[]>(body);  // verifica o type byte[] 
            Assert.Equal(bytes, body); // verifica se tem o mesmo conteúdo

            Assert.IsType<string>(message); // verifica o type string

            Assert.IsType<Ticket>(ticket); // verifica o type Ticket

        }

    }
}
