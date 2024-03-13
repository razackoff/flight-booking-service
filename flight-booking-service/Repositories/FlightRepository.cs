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
    
    public void Add(Flight flight)
    {
        if (flight == null)
            throw new ArgumentNullException(nameof(flight));

        _context.Flights.Add(flight);
        _context.SaveChanges();
    }
    
    public void Update(Flight flight)
    {
        if (flight == null)
            throw new ArgumentNullException(nameof(flight));

        var existingFlight = _context.Flights.FirstOrDefault(f => f.Id == flight.Id);
        if (existingFlight != null)
        {
            existingFlight.DepartureLocation = flight.DepartureLocation;
            existingFlight.Destination = flight.Destination;
            existingFlight.DepartureDateTime = flight.DepartureDateTime;
            existingFlight.ArrivalDateTime = flight.ArrivalDateTime;
            existingFlight.AvailableEconomySeats = flight.AvailableEconomySeats;
            existingFlight.AvailableBusinessSeats = flight.AvailableBusinessSeats;
            existingFlight.AvailableFirstClassSeats = flight.AvailableFirstClassSeats;
            existingFlight.EconomyClassPrice = flight.EconomyClassPrice;
            existingFlight.BusinessClassPrice = flight.BusinessClassPrice;
            existingFlight.FirstClassPrice = flight.FirstClassPrice;
            existingFlight.AirlineId = flight.AirlineId;
            existingFlight.AircraftType = flight.AircraftType;
            // Update other fields as needed

            _context.SaveChanges();
        }
    }

    public void Delete(string id)
    {
        var flight = _context.Flights.FirstOrDefault(f => f.Id == id);
        if (flight != null)
        {
            _context.Flights.Remove(flight);
            _context.SaveChanges();
        }
    }
}