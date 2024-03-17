using flight_booking_service.DTOs;
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
    
    public IEnumerable<Airline> GetAllAirlines()
    {
        return _airlineRepository.GetAll();
    }
    
    public Airline GetAirlineById(string airlineId)
    {
        return _airlineRepository.GetById(airlineId);
    }
    
    public string AddAirline(AirlineDTO airlineDto)
    {
        var airlineId = _airlineRepository.Add(airlineDto);
        return airlineId;
    }

    public void UpdateAirline(string airlineId, AirlineDTO airlineDTO)
    {
        _airlineRepository.Update(airlineId, airlineDTO);
    }

    public void DeleteAirline(string airlineId)
    {
        _airlineRepository.Delete(airlineId);
    }
}
