using flight_booking_service.DTOs;
using flight_booking_service.Models;

namespace flight_booking_service.Repositories;

public interface IDestinationRepository
{
    IEnumerable<DestinationWithCoordinatesDTO> GetAll();
    DestinationWithCoordinatesDTO GetById(string id);
    Coordinates GetCoordinatesById(string id);
    string Add(DestinationDTO destinationDTO);
    void Update(string destinationId, DestinationDTO destinationDTO);
    void Delete(string destinationId);
}