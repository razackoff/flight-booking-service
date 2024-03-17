using flight_booking_service.DTOs;
using flight_booking_service.Models;

namespace flight_booking_service.Services;

public interface IFlightService
{
    IEnumerable<Flight> GetAllFlights();
    Flight GetFlightById(string flightId);
    IEnumerable<Flight> SearchFlights(FlightSearchParameters parameters);
    string AddFlight(FlightDTO flightDTO);
    void UpdateFlight(string flightId, FlightDTO flightDTO);
    void DeleteFlight(string flightId);
}