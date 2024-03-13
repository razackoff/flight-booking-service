using flight_booking_service.Models;
using hotel_booking_service.Data;

namespace flight_booking_service.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly ApplicationDbContext _context;

    public TicketRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Ticket> GetAll()
    {
        return _context.Tickets.ToList();
    }

    public Ticket GetById(string id)
    {
        return _context.Tickets.FirstOrDefault(t => t.Id == id);
    }

    public Ticket BookTicket(TicketBookingRequest bookingRequest)
    {
        // Создание билета и сохранение его в базе данных
        // Пример:
        var newTicket = new Ticket
        {
            UserId = bookingRequest.UserId,
            FlightId = bookingRequest.FlightId,
            //NumberOfSeats = bookingRequest.NumberOfSeats,
            // Другие необходимые поля билета
        };

        _context.Tickets.Add(newTicket);
        _context.SaveChanges();

        return newTicket;
    }

    public void Add(Ticket ticket)
    {
        if (ticket == null)
            throw new ArgumentNullException(nameof(ticket));

        _context.Tickets.Add(ticket);
        _context.SaveChanges();
    }
    
    public void Update(Ticket ticket)
    {
        if (ticket == null)
            throw new ArgumentNullException(nameof(ticket));

        var existingTicket = _context.Tickets.FirstOrDefault(t => t.Id == ticket.Id);
        if (existingTicket != null)
        {
            existingTicket.FlightId = ticket.FlightId;
            existingTicket.UserId = ticket.UserId;
            existingTicket.ServiceClass = ticket.ServiceClass;
            existingTicket.Price = ticket.Price;
            existingTicket.AdditionalInfo = ticket.AdditionalInfo;
            // Update other fields as needed

            _context.SaveChanges();
        }
    }

    public void Delete(string id)
    {
        var ticket = _context.Tickets.FirstOrDefault(t => t.Id == id);
        if (ticket != null)
        {
            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
        }
    }
}