using flight_booking_service.Models;

namespace flight_booking_service.Services;

public interface ITicketService
{
    void AddTicket(Ticket ticket);
    Ticket GetTicketById(string ticketId);
    Ticket BookTicket(TicketBookingRequest bookingRequest);
    IEnumerable<Ticket> GetAllTickets();
    void UpdateTicket(string ticketId, Ticket ticket);
    void DeleteTicket(string ticketId);
}