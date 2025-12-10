using FlightTickets.Models.Models;

namespace FlightTickets.ConsumerAPI.Repositories.Interfaces
{
    public interface IConsumerRepository
    {
        Task SaveApprovedTicketsAsync(Ticket ticket);

        Task SaveDeniedTicketsAsync(Ticket ticket);
    }
}
