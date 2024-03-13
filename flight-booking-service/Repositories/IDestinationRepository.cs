using flight_booking_service.Models;

namespace flight_booking_service.Repositories;

public interface IDestinationRepository
{
    void Add(Destination destination);
    Destination GetById(string id);
    IEnumerable<Destination> GetAll();
    void Update(Destination destination);
    void Delete(string id);
}