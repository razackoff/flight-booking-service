using flight_booking_service.Models;

namespace flight_booking_service.Repositories;

public interface IFlightRepository
{
    void Add(Flight flight);
    Flight GetById(string id);
    IEnumerable<Flight> SearchFlights(FlightSearchParameters parameters);
    IEnumerable<Flight> GetAll();
    void Update(Flight flight);
    void Delete(string id);
}