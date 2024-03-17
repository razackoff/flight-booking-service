using flight_booking_service.DTOs;
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

    public IEnumerable<DestinationWithCoordinatesDTO> GetAllDestinations()
    {
        return _destinationRepository.GetAll();
    }
    
    public DestinationWithCoordinatesDTO GetDestinationById(string destinationId)
    {
        return _destinationRepository.GetById(destinationId);
    }

    public string AddDestination(DestinationDTO destinationDTO)
    {
        return _destinationRepository.Add(destinationDTO);
    }
    
    public void UpdateDestination(string destinationId, DestinationDTO destinationDTO)
    {
        _destinationRepository.Update(destinationId, destinationDTO);
    }

    public void DeleteDestination(string destinationId)
    {
        _destinationRepository.Delete(destinationId);
    }
}
