using flight_booking_service.Models;

namespace flight_booking_service.Services;

public interface IDestinationService
{
    void AddDestination(Destination destination);
    Destination GetDestinationById(string destinationId);
    IEnumerable<Destination> GetAllDestinations();
    void UpdateDestination(string destinationId, Destination destination);
    void DeleteDestination(string destinationId);
}