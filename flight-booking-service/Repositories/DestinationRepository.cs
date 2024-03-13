using flight_booking_service.Models;
using hotel_booking_service.Data;
using Microsoft.EntityFrameworkCore;

namespace flight_booking_service.Repositories;

public class DestinationRepository : IDestinationRepository
{
    private readonly ApplicationDbContext _context;

    public DestinationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Destination destination)
    {
        if (destination == null)
            throw new ArgumentNullException(nameof(destination));

        _context.Destinations.Add(destination);
        _context.SaveChanges();
    }

    public Destination GetById(string id)
    {
        return _context.Destinations.FirstOrDefault(d => d.Id == id);
    }

    public IEnumerable<Destination> GetAll()
    {
        return _context.Destinations.ToList();
    }

    public void Update(Destination destination)
    {
        if (destination == null)
            throw new ArgumentNullException(nameof(destination));

        var existingDestination = _context.Destinations.FirstOrDefault(d => d.Id == destination.Id);
        if (existingDestination != null)
        {
            existingDestination.Name = destination.Name;
            existingDestination.Code = destination.Code;
            existingDestination.Coordinates = destination.Coordinates;
            existingDestination.AdditionalInfo = destination.AdditionalInfo;

            _context.SaveChanges();
        }
    }

    public void Delete(string id)
    {
        var destination = _context.Destinations.FirstOrDefault(d => d.Id == id);
        if (destination != null)
        {
            _context.Destinations.Remove(destination);
            _context.SaveChanges();
        }
    }
}