using flight_booking_service.DTOs;
using flight_booking_service.Models;
using flight_booking_service.Repositories;

namespace flight_booking_service.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public IEnumerable<Ticket> GetAllTickets()
    {
        return _ticketRepository.GetAll();
    }

    public Ticket GetTicketById(string ticketId)
    {
        return _ticketRepository.GetById(ticketId);
    }
    
    public Ticket BookTicket(TicketBookingRequest bookingRequest)
    {
        return _ticketRepository.BookTicket(bookingRequest);
    }
    
    public string AddTicket(TicketDTO ticketDTO)
    {
        var ticketID = _ticketRepository.Add(ticketDTO);
        return ticketID;
    }
    
    public void UpdateTicket(string ticketId, TicketDTO ticketDTO)
    {
        _ticketRepository.Update(ticketId, ticketDTO);
    }
 
    public void DeleteTicket(string ticketId)
    {
        _ticketRepository.Delete(ticketId);
    }
}