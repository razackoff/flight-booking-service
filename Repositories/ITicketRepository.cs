using flight_booking_service.DTOs;
using flight_booking_service.Models;

namespace flight_booking_service.Repositories;

public interface ITicketRepository
{
    IEnumerable<Ticket> GetAll();
    Ticket GetById(string id);
    Ticket BookTicket(TicketBookingRequest bookingRequest);
    string Add(TicketDTO ticketDTO);
    void Update(string ticketID, TicketDTO ticketDTO);
    void Delete(string ticketID);
}