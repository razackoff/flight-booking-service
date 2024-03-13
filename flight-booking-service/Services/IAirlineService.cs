using flight_booking_service.Models;

namespace flight_booking_service.Services;

public interface IAirlineService
{
    void AddAirline(Airline airline);
    Airline GetAirlineById(string airlineId);
    IEnumerable<Airline> GetAllAirlines();
    void UpdateAirline(string airlineId, Airline airline);
    void DeleteAirline(string airlineId);
}