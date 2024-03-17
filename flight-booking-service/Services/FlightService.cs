using flight_booking_service.DTOs;
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

    public string AddFlight(FlightDTO flightDTO)
    {
        var flightID = _flightRepository.Add(flightDTO);
        return flightID;
    }
    
    public void UpdateFlight(string flightId, FlightDTO flightDTO)
    {
        _flightRepository.Update(flightId, flightDTO);
    }

    public void DeleteFlight(string flightId)
    {
        _flightRepository.Delete(flightId);
    }
}
