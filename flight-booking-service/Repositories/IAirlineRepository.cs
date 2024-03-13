using flight_booking_service.Models;

namespace flight_booking_service.Repositories;

public interface IAirlineRepository
{
    void Add(Airline airline);
    Airline GetById(string id);
    IEnumerable<Airline> GetAll();
    void Update(Airline airline);
    void Delete(string id);
}