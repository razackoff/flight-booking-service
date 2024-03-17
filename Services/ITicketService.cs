using flight_booking_service.DTOs;
using flight_booking_service.Models;

namespace flight_booking_service.Services;

public interface ITicketService
{
    IEnumerable<Ticket> GetAllTickets();
    Ticket GetTicketById(string ticketId);
    Ticket BookTicket(TicketBookingRequest bookingRequest);
    string AddTicket(TicketDTO ticketDTO);
    void UpdateTicket(string ticketId, TicketDTO ticketDTO);
    void DeleteTicket(string ticketId);
}