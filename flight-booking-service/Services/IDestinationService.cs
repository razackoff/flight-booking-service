using flight_booking_service.DTOs;
using flight_booking_service.Models;

namespace flight_booking_service.Services;

public interface IDestinationService
{
    IEnumerable<DestinationWithCoordinatesDTO> GetAllDestinations();
    DestinationWithCoordinatesDTO GetDestinationById(string destinationId);
    string AddDestination(DestinationDTO destinationDTO);
    void UpdateDestination(string destinationId, DestinationDTO destinationDTO);
    void DeleteDestination(string destinationId);
}