using flight_booking_service.DTOs;
using flight_booking_service.Models;

namespace flight_booking_service.Repositories;

public interface IAirlineRepository
{
    IEnumerable<Airline> GetAll();
    Airline GetById(string id);
    string Add(AirlineDTO airlineDto);
    void Update(string airlineId, AirlineDTO airlineDTO);
    void Delete(string id);
}