using flight_booking_service.Models;
using flight_booking_service.Repositories;

namespace flight_booking_service.Services;

public class AirlineService : IAirlineService
{
    private readonly IAirlineRepository _airlineRepository;

    public AirlineService(IAirlineRepository airlineRepository)
    {
        _airlineRepository = airlineRepository;
    }

    public void AddAirline(Airline airline)
    {
        _airlineRepository.Add(airline);
    }

    public Airline GetAirlineById(string airlineId)
    {
        return _airlineRepository.GetById(airlineId);
    }

    public IEnumerable<Airline> GetAllAirlines()
    {
        return _airlineRepository.GetAll();
    }

    public void UpdateAirline(string airlineId, Airline airline)
    {
        _airlineRepository.Update(airline);
    }

    public void DeleteAirline(string airlineId)
    {
        _airlineRepository.Delete(airlineId);
    }
}
