using flight_booking_service.DTOs;
using flight_booking_service.Models;

namespace flight_booking_service.Services;

public interface IAirlineService
{
    IEnumerable<Airline> GetAllAirlines();
    Airline GetAirlineById(string airlineId);
    string AddAirline(AirlineDTO airlineDTO);
    void UpdateAirline(string airlineId, AirlineDTO airlineDTO);
    void DeleteAirline(string airlineId);
}