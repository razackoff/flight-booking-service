using flight_booking_service.DTOs;
using flight_booking_service.Models;

namespace flight_booking_service.Repositories;

public interface IFlightRepository
{
    IEnumerable<Flight> GetAll();
    Flight GetById(string id);
    IEnumerable<Flight> SearchFlights(FlightSearchParameters parameters);
    string Add(FlightDTO flightDTO);
    void Update(string flightID, FlightDTO flightDTO);
    void Delete(string flightID);
}