using flight_booking_service.DTOs;
using flight_booking_service.Exceptions;
using flight_booking_service.Models;
using hotel_booking_service.Data;
using Microsoft.EntityFrameworkCore;

namespace flight_booking_service.Repositories;

public class FlightRepository : IFlightRepository
{
    private readonly ApplicationDbContext _context;

    public FlightRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Flight> GetAll()
    {
        return _context.Flights.ToList();
    }
    
    public Flight GetById(string id)
    {
        return _context.Flights.FirstOrDefault(f => f.Id == id);
    }
    
    public IEnumerable<Flight> SearchFlights(FlightSearchParameters parameters)
    {
        // Реализация поиска рейсов в базе данных или во внешнем источнике
        // на основе параметров поиска
        // Пример:
        return _context.Flights
            .Where(f => f.DepartureLocation == parameters.DepartureAirport 
                        && f.Destination == parameters.DestinationAirport 
                        && f.DepartureDateTime.Date == parameters.DepartureDate.Date)
            .ToList();
    }
    
    public string Add(FlightDTO flightDTO)
    {
        if (flightDTO == null)
            throw new ArgumentNullException(nameof(flightDTO));

        var flightID = Guid.NewGuid().ToString();

        var flight = new Flight
        {
            Id = flightID,
            DepartureLocation = flightDTO.DepartureLocation,
            Destination = flightDTO.Destination,
            DepartureDateTime = flightDTO.DepartureDateTime,
            ArrivalDateTime  = flightDTO.ArrivalDateTime,
            AvailableEconomySeats = flightDTO.AvailableEconomySeats,
            AvailableBusinessSeats = flightDTO.AvailableBusinessSeats,
            AvailableFirstClassSeats = flightDTO.AvailableFirstClassSeats,
            EconomyClassPrice = flightDTO.EconomyClassPrice,
            BusinessClassPrice = flightDTO.BusinessClassPrice,
            FirstClassPrice = flightDTO.FirstClassPrice,
            AirlineId = flightDTO.AirlineId,
            AircraftType = flightDTO.AircraftType
        };
        
        _context.Flights.Add(flight);
        _context.SaveChanges();

        return flightID;
    }
    
    public void Update(string flightID, FlightDTO flightDTO)
    {
        if (flightDTO == null)
            throw new ArgumentNullException(nameof(flightDTO));

        var existingFlight = _context.Flights.FirstOrDefault(f => f.Id == flightID);
        
        if (existingFlight != null)
        {
            existingFlight.DepartureLocation = flightDTO.DepartureLocation;
            existingFlight.Destination = flightDTO.Destination;
            existingFlight.DepartureDateTime = flightDTO.DepartureDateTime;
            existingFlight.ArrivalDateTime = flightDTO.ArrivalDateTime;
            existingFlight.AvailableEconomySeats = flightDTO.AvailableEconomySeats;
            existingFlight.AvailableBusinessSeats = flightDTO.AvailableBusinessSeats;
            existingFlight.AvailableFirstClassSeats = flightDTO.AvailableFirstClassSeats;
            existingFlight.EconomyClassPrice = flightDTO.EconomyClassPrice;
            existingFlight.BusinessClassPrice = flightDTO.BusinessClassPrice;
            existingFlight.FirstClassPrice = flightDTO.FirstClassPrice;
            existingFlight.AirlineId = flightDTO.AirlineId;
            existingFlight.AircraftType = flightDTO.AircraftType;

            _context.SaveChanges();
        }
        else
        {
            throw new NotFoundException($"Flight with ID {flightID} not found.");
        }
    }

    public void Delete(string flightID)
    {
        var flight = _context.Flights.FirstOrDefault(f => f.Id == flightID);
        
        if (flight != null)
        {
            _context.Flights.Remove(flight);
            _context.SaveChanges();
        }
        else
        {
            throw new NotFoundException($"Flight with ID {flightID} not found.");
        }
    }
}