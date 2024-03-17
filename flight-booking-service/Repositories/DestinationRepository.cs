using flight_booking_service.DTOs;
using flight_booking_service.Exceptions;
using flight_booking_service.Models;
using hotel_booking_service.Data;
using Microsoft.EntityFrameworkCore;

namespace flight_booking_service.Repositories;

public class DestinationRepository : IDestinationRepository
{
    private readonly ApplicationDbContext _context;

    public DestinationRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public IEnumerable<DestinationWithCoordinatesDTO> GetAll()
    {
        var destinationsWithCoordinates = _context.Destinations
            .Select(destination => new DestinationWithCoordinatesDTO
            {
                Id = destination.Id,
                Name = destination.Name,
                Code = destination.Code,
                Coordinates = _context.Coordinates.FirstOrDefault(c => c.Id == destination.CoordinatesID),
                AdditionalInfo = destination.AdditionalInfo
            })
            .ToList();

        return destinationsWithCoordinates;
    }
    

    public DestinationWithCoordinatesDTO GetById(string id)
    {
        var destination = _context.Destinations.FirstOrDefault(d => d.Id == id);
        var coordinates = _context.Coordinates.FirstOrDefault(d => d.Id == destination.CoordinatesID);

        var destinationWithCoordinatesDTO = new DestinationWithCoordinatesDTO
        {
            Id = destination.Id,
            Name = destination.Name,
            Code = destination.Code,
            Coordinates = coordinates,
            AdditionalInfo = destination.AdditionalInfo
        };

        return destinationWithCoordinatesDTO;
    }
    
    public Coordinates GetCoordinatesById(string id)
    {
        return _context.Coordinates.FirstOrDefault(d => d.Id == id);
    }

    public string Add(DestinationDTO destinationDTO)
    {
        if (destinationDTO== null)
            throw new ArgumentNullException(nameof(destinationDTO));

        var destinationID = Guid.NewGuid().ToString();

        var coordinatesID = Guid.NewGuid().ToString();
        
        var coordinates = new Coordinates
        {
            Id = coordinatesID,
            Latitude = destinationDTO.CoordinatesDTO.Latitude,
            Longitude = destinationDTO.CoordinatesDTO.Longitude
        };
        
        var destination = new Destination
        {
            Id = destinationID,
            Name = destinationDTO.Name,
            Code = destinationDTO.Code,
            CoordinatesID = coordinatesID,
            AdditionalInfo = destinationDTO.AdditionalInfo
        };
        
        _context.Destinations.Add(destination);
        _context.Coordinates.Add(coordinates);
        _context.SaveChanges();

        return destinationID;
    }

    public void Update(string destinationId, DestinationDTO destinationDTO)
    {
        if (destinationDTO == null)
            throw new ArgumentNullException(nameof(destinationDTO));

        var existingDestination = _context.Destinations.FirstOrDefault(d => d.Id == destinationId);
        if (existingDestination != null)
        {
            existingDestination.Name = destinationDTO.Name;
            existingDestination.Code = destinationDTO.Code;
            existingDestination.AdditionalInfo = destinationDTO.AdditionalInfo;

            var existingCoordinates = _context.Coordinates.FirstOrDefault(d => d.Id == existingDestination.CoordinatesID);

            existingCoordinates.Latitude = destinationDTO.CoordinatesDTO.Latitude;
            existingCoordinates.Longitude = destinationDTO.CoordinatesDTO.Longitude;
            
            _context.SaveChanges();
        }
        else
        {
            throw new NotFoundException($"Destination with ID {destinationId} not found.");
        }
    }

    public void Delete(string destinationId)
    {
        var destination = _context.Destinations.FirstOrDefault(d => d.Id == destinationId);
        if (destination != null)
        {
            _context.Destinations.Remove(destination);
            _context.SaveChanges();
        }
    }
}