using flight_booking_service.Models;
using flight_booking_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace flight_booking_service.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IAirlineService _airlineService;
    private readonly IDestinationService _destinationService;
    private readonly IFlightService _flightService;
    private readonly ITicketService _ticketService;

    public ClientController(
        IAirlineService airlineService,
        IDestinationService destinationService,
        IFlightService flightService,
        ITicketService ticketService)
    {
        _airlineService = airlineService;
        _destinationService = destinationService;
        _flightService = flightService;
        _ticketService = ticketService;
    }

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

    [HttpGet("GetAllDestinations")]
    public IActionResult GetAllDestinations()
    {
        var destinations = _destinationService.GetAllDestinations();
        return Ok(destinations);
    }
    
    [HttpGet("GetAvailableDestinations")]
    public IActionResult GetAvailableDestinations()
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
    
    [HttpPost("SearchFlights")]
    public IActionResult SearchFlights([FromQuery] FlightSearchParameters parameters)
    {
        var foundFlights = _flightService.SearchFlights(parameters);
        return Ok(foundFlights);
    }
    
    [HttpPost("BookTicket")]
    public IActionResult BookTicket([FromBody] TicketBookingRequest bookingRequest)
    {
        try
        {
            var bookedTicket = _ticketService.BookTicket(bookingRequest);
            return Ok(bookedTicket);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}