using flight_booking_service.Models;
using flight_booking_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace flight_booking_service.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ManagementController : ControllerBase
{
    private readonly IAirlineService _airlineService;
    private readonly IDestinationService _destinationService;
    private readonly IFlightService _flightService;
    private readonly ITicketService _ticketService;
    
    public ManagementController(
        IAirlineService airlineService,
        IDestinationService destinationService,
        ITicketService ticketService,
        IFlightService flightService)
    {
        _airlineService = airlineService;
        _destinationService = destinationService;
        _flightService = flightService;
        _ticketService = ticketService;
    }

    //Airline
    [HttpGet("GetAllAirlines")]
    public IActionResult GetAllAirlines()
    {
        var airlines = _airlineService.GetAllAirlines();
        return Ok(airlines);
    }

    [HttpGet("GetAirlineById")]
    public IActionResult GetAirlineById([FromQuery] string airlineId)
    {
        var airline = _airlineService.GetAirlineById(airlineId);
        if (airline == null)
            return NotFound();
        return Ok(airline);
    }

    [HttpPost("AddAirline")]
    public IActionResult AddAirline([FromBody] Airline airline)
    {
        _airlineService.AddAirline(airline);
        return Ok();
    }

    [HttpPut("UpdateAirline")]
    public IActionResult UpdateAirline([FromQuery] string airlineId, [FromBody] Airline airline)
    {
        _airlineService.UpdateAirline(airlineId, airline);
        return Ok();
    }

    [HttpDelete("DeleteAirline")]
    public IActionResult DeleteAirline([FromQuery] string airlineId)
    {
        _airlineService.DeleteAirline(airlineId);
        return Ok();
    }
    
    //Ticket
    [HttpGet("GetAllTickets")]
    public IActionResult GetAllTickets()
    {
        var tickets = _ticketService.GetAllTickets();
        return Ok(tickets);
    }
    
    [HttpGet("GetTicketById")]
    public IActionResult GetTicketById([FromQuery] string ticketId)
    {
        var ticket = _ticketService.GetTicketById(ticketId);
        if (ticket == null)
            return NotFound();
        return Ok(ticket);
    }
    
    [HttpPost("AddTicket")]
    public IActionResult AddTicket([FromBody] Ticket ticket)
    {
        _ticketService.AddTicket(ticket);
        return Ok();
    }

    [HttpPut("UpdateTicket")]
    public IActionResult UpdateTicket([FromQuery] string ticketId, [FromBody] Ticket ticket)
    {
        _ticketService.UpdateTicket(ticketId, ticket);
        return Ok();
    }

    [HttpDelete("DeleteTicket")]
    public IActionResult DeleteTicket([FromQuery] string ticketId)
    {
        _ticketService.DeleteTicket(ticketId);
        return Ok();
    }
    
    //Flight
    [HttpGet("GetAllFlights")]
    public IActionResult GetAllFlights()
    {
        var flights = _flightService.GetAllFlights();
        return Ok(flights);
    }

    [HttpGet("GetFlightById")]
    public IActionResult GetFlightById([FromQuery] string flightId)
    {
        var flight = _flightService.GetFlightById(flightId);
        if (flight == null)
            return NotFound();
        return Ok(flight);
    }

    [HttpPost("AddFlight")]
    public IActionResult AddFlight([FromBody] Flight flight)
    {
        _flightService.AddFlight(flight);
        return Ok();
    }

    [HttpPut("UpdateFlight")]
    public IActionResult UpdateFlight([FromQuery] string flightId, [FromBody] Flight flight)
    {
        _flightService.UpdateFlight(flightId, flight);
        return Ok();
    }

    [HttpDelete("DeleteFlight")]
    public IActionResult DeleteFlight([FromQuery] string flightId)
    {
        _flightService.DeleteFlight(flightId);
        return Ok();
    }
    
    //Destination
    [HttpGet("GetAllDestinations")]
    public IActionResult GetAllDestinations()
    {
        var destinations = _destinationService.GetAllDestinations();
        return Ok(destinations);
    }
    
    [HttpGet("GetDestinationById")]
    public IActionResult GetDestinationById([FromQuery] string destinationId)
    {
        var destination = _destinationService.GetDestinationById(destinationId);
        if (destination == null)
            return NotFound();
        return Ok(destination);
    }

    [HttpPost("AddDestination")]
    public IActionResult AddDestination([FromBody] Destination destination)
    {
        _destinationService.AddDestination(destination);
        return Ok();
    }
    
    [HttpPut("UpdateDestination")]
    public IActionResult UpdateDestination([FromQuery] string destinationId, [FromBody] Destination destination)
    {
        _destinationService.UpdateDestination(destinationId, destination);
        return Ok();
    }

    [HttpDelete("DeleteDestination")]
    public IActionResult DeleteDestination([FromQuery] string destinationId)
    {
        _destinationService.DeleteDestination(destinationId);
        return Ok();
    }
}