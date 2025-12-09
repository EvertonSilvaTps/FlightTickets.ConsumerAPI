using FlightTickets.Models.DTOs;
using FlightTickets.Models.Models;
using FlightTickets.OrderAPI.Services.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace FlightTickets.OrderAPI.Services
{
    public class TicketService : ITicketService
    {
        public async Task<TicketResponseDTO> CreateTicketAsync(TicketRequestDTO ticketRequest)
        {
            try
            {

                // Objeto Ticket
                var newTicket = new Ticket
                (
                    ticketRequest.PassengerName,
                    ticketRequest.FlightNumber,
                    ticketRequest.SeatNumber,
                    ticketRequest.Price
                );


                // Uso do RabbitMQ

                var factory = new ConnectionFactory { HostName = "localhost"};  // Endereço de quem vou me conectar
                using var connection = await factory.CreateConnectionAsync();  // Created conexão

                using var channel = await connection.CreateChannelAsync(); // Created Channel


                // Created a fila
                await channel.QueueDeclareAsync(queue: "TicketOrder",  // name da fila
                                                durable: false,
                                                exclusive: false,
                                                autoDelete: false,
                                                arguments: null);


                var ticketString = JsonSerializer.Serialize(newTicket);  // converter o objeto Ticket para string

                var queueTicket = Encoding.UTF8.GetBytes(ticketString);  // converte-lo para array de bytes

                // publicar a fila
                await channel.BasicPublishAsync(exchange: string.Empty,
                                                routingKey: "TicketOrder",
                                                body: queueTicket);



                // Passar meu objeto do type Ticket para o TicketResponseDTO
                var createdTicket = new TicketResponseDTO 
                {
                    Id = newTicket.Id.ToString(),
                    PassengerName = newTicket.PassengerName,
                    FlightNumber = newTicket.FlightNumber,
                    SeatNumber = newTicket.SeatNumber,
                    Price = newTicket.Price,
                };


                return createdTicket;  // retornando minha fila

            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while creating the ticket.", ex);
            }
            
        }
    }
}
