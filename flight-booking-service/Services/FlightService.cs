using flight_booking_service.Models;
using flight_booking_service.Repositories;

namespace flight_booking_service.Services;

public class FlightService : IFlightService
{
    private readonly IFlightRepository _flightRepository;

    public FlightService(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public void AddFlight(Flight flight)
    {
        _flightRepository.Add(flight);
    }

    public Flight GetFlightById(string flightId)
    {
        return _flightRepository.GetById(flightId);
    }

    public IEnumerable<Flight> SearchFlights(FlightSearchParameters parameters)
    {
        return _flightRepository.SearchFlights(parameters);
    }
    
    public IEnumerable<Flight> GetAllFlights()
    {
        return _flightRepository.GetAll();
    }

    public void UpdateFlight(string flightId, Flight flight)
    {
        _flightRepository.Update(flight);
    }

    public void DeleteFlight(string flightId)
    {
        _flightRepository.Delete(flightId);
    }
}
