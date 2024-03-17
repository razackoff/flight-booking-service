using flight_booking_service.DTOs;
using flight_booking_service.Exceptions;
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
        var ticketID = Guid.NewGuid().ToString();
        
        var newTicket = new Ticket
        {
            Id = ticketID,
            UserId = bookingRequest.UserId,
            FlightId = bookingRequest.FlightId,
            ServiceClass = "",
            Price = 0,
            AdditionalInfo = ""
            //NumberOfSeats = bookingRequest.NumberOfSeats,
        };

        _context.Tickets.Add(newTicket);
        _context.SaveChanges();

        return newTicket;
    }

    public string Add(TicketDTO ticketDTO)
    {
        if (ticketDTO == null)
            throw new ArgumentNullException(nameof(ticketDTO));

        var ticketID = Guid.NewGuid().ToString();
        
        var ticket = new Ticket
        {
            Id = ticketID,
            FlightId = ticketDTO.FlightId,
            UserId = ticketDTO.UserId,
            ServiceClass = ticketDTO.ServiceClass,
            Price = ticketDTO.Price,
            AdditionalInfo = ticketDTO.AdditionalInfo
        };
        
        _context.Tickets.Add(ticket);
        _context.SaveChanges();

        return ticketID;
    }
    
    public void Update(string ticketID, TicketDTO ticketDTO)
    {
        if (ticketDTO == null)
            throw new ArgumentNullException(nameof(ticketDTO));

        var existingTicket = _context.Tickets.FirstOrDefault(t => t.Id == ticketID);
        if (existingTicket != null)
        {
            existingTicket.FlightId = ticketDTO.FlightId;
            existingTicket.UserId = ticketDTO.UserId;
            existingTicket.ServiceClass = ticketDTO.ServiceClass;
            existingTicket.Price = ticketDTO.Price;
            existingTicket.AdditionalInfo = ticketDTO.AdditionalInfo;
            // Update other fields as needed

            _context.SaveChanges();
        }
        else
        {
            throw new NotFoundException($"Ticket with ID {ticketID} not found.");
        }
    }

    public void Delete(string ticketID)
    {
        var ticket = _context.Tickets.FirstOrDefault(t => t.Id == ticketID);
        if (ticket != null)
        {
            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
        }
        else
        {
            throw new NotFoundException($"Ticket with ID {ticketID} not found.");
        }
    }
}