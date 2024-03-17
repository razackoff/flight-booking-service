using flight_booking_service.DTOs;
using flight_booking_service.Exceptions;
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

    public IEnumerable<Airline> GetAll()
    {
        return _context.Airlines.ToList();
    }
    
    public Airline GetById(string id)
    {
        return _context.Airlines.FirstOrDefault(a => a.Id == id);
    }

    public string Add(AirlineDTO airlineDto)
    {
        if (airlineDto == null)
            throw new ArgumentNullException(nameof(airlineDto));

        var airlineID = Guid.NewGuid().ToString();
        
        var airline = new Airline
        {
            Id = airlineID,
            Name = airlineDto.Name,
            Country = airlineDto.Country,
            Description = airlineDto.Description
        };
        
        _context.Airlines.Add(airline);
        _context.SaveChanges();

        return airlineID;
    }
    
    public void Update(string airlineId, AirlineDTO airlineDTO)
    {
        if (airlineDTO == null)
            throw new ArgumentNullException(nameof(airlineDTO));

        var existingAirline = _context.Airlines.FirstOrDefault(a => a.Id == airlineId);
        if (existingAirline != null)
        {
            existingAirline.Name = airlineDTO.Name;
            existingAirline.Country = airlineDTO.Country;
            existingAirline.Description = airlineDTO.Description;

            _context.SaveChanges();
        }
        else
        {
            throw new NotFoundException($"Airline with ID {airlineId} not found.");
        }
    }

    public void Delete(string airlineId)
    {
        var airline = _context.Airlines.FirstOrDefault(a => a.Id == airlineId);
        if (airline != null)
        {
            _context.Airlines.Remove(airline);
            _context.SaveChanges();
        }
        else
        {
            throw new NotFoundException($"Airline with ID {airlineId} not found.");
        }
    }
}