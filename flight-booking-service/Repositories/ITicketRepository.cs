using flight_booking_service.Models;

namespace flight_booking_service.Repositories;

public interface ITicketRepository
{
    IEnumerable<Ticket> GetAll();
    Ticket GetById(string id);
    Ticket BookTicket(TicketBookingRequest bookingRequest);
    void Add(Ticket ticket);
    void Update(Ticket ticket);
    void Delete(string id);
}