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
        // Валидация и обработка запроса
        // Реализация может варьироваться в зависимости от требований системы
        // Пример:
        return _ticketRepository.BookTicket(bookingRequest);
    }
    
    public void AddTicket(Ticket ticket)
    {
        _ticketRepository.Add(ticket);
    }
    
    public void UpdateTicket(string ticketId, Ticket ticket)
    {
        _ticketRepository.Update(ticket);
    }

    public void DeleteTicket(string ticketId)
    {
        _ticketRepository.Delete(ticketId);
    }
}