using flight_booking_service.Models;
using hotel_booking_service.Data;
using Microsoft.EntityFrameworkCore;

namespace flight_booking_service.Repositories;

public class AirlineRepository : IAirlineRepository
{
    private readonly ApplicationDbContext _context;

    public AirlineRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Airline airline)
    {
        if (airline == null)
            throw new ArgumentNullException(nameof(airline));

        _context.Airlines.Add(airline);
        _context.SaveChanges();
    }

    public Airline GetById(string id)
    {
        return _context.Airlines.FirstOrDefault(a => a.Id == id);
    }

    public IEnumerable<Airline> GetAll()
    {
        return _context.Airlines.ToList();
    }

    public void Update(Airline airline)
    {
        if (airline == null)
            throw new ArgumentNullException(nameof(airline));

        var existingAirline = _context.Airlines.FirstOrDefault(a => a.Id == airline.Id);
        if (existingAirline != null)
        {
            existingAirline.Name = airline.Name;
            existingAirline.Country = airline.Country;
            existingAirline.Description = airline.Description;

            _context.SaveChanges();
        }
    }

    public void Delete(string id)
    {
        var airline = _context.Airlines.FirstOrDefault(a => a.Id == id);
        if (airline != null)
        {
            _context.Airlines.Remove(airline);
            _context.SaveChanges();
        }
    }
}