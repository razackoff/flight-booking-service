using flight_booking_service.Models;

namespace flight_booking_service.Services;

public interface IFlightService
{
    void AddFlight(Flight flight);
    Flight GetFlightById(string flightId);
    IEnumerable<Flight> SearchFlights(FlightSearchParameters parameters);
    IEnumerable<Flight> GetAllFlights();
    void UpdateFlight(string flightId, Flight flight);
    void DeleteFlight(string flightId);
}