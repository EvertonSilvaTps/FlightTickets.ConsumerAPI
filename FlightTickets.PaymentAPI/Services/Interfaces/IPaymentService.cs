using FlightTickets.Models.Models;

namespace FlightTickets.PaymentAPI.Services.Interfaces
{
    public interface IPaymentService
    {
        Task GetTicketsFromQueueAsync();

        Task ValidatePaymentTicket(Ticket ticket);

    }
}
