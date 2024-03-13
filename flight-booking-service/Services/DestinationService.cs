using flight_booking_service.Models;
using flight_booking_service.Repositories;

namespace flight_booking_service.Services;

public class DestinationService : IDestinationService
{
    private readonly IDestinationRepository _destinationRepository;

    public DestinationService(IDestinationRepository destinationRepository)
    {
        _destinationRepository = destinationRepository;
    }

    public void AddDestination(Destination destination)
    {
        _destinationRepository.Add(destination);
    }

    public Destination GetDestinationById(string destinationId)
    {
        return _destinationRepository.GetById(destinationId);
    }

    public IEnumerable<Destination> GetAllDestinations()
    {
        return _destinationRepository.GetAll();
    }

    public void UpdateDestination(string destinationId, Destination destination)
    {
        _destinationRepository.Update(destination);
    }

    public void DeleteDestination(string destinationId)
    {
        _destinationRepository.Delete(destinationId);
    }
}
