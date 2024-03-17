using flight_booking_service.DTOs;
using flight_booking_service.Exceptions;
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
    public IActionResult AddAirline([FromBody] AirlineDTO airlineDTO)
    {
        try
        {
            var airlineId = _airlineService.AddAirline(airlineDTO);
            return Ok(airlineId);
        }
        catch (ArgumentException ex)
        {
            // Логирование ошибки
            return BadRequest(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (Exception ex)
        {
            // Логирование ошибки
            return StatusCode(500, "Internal server error"); // Вернуть статус код 500 с общим сообщением об ошибке
        }
    }

    [HttpPut("UpdateAirline")]
    public IActionResult UpdateAirline([FromQuery] string airlineId, [FromBody] AirlineDTO airlineDTO)
    {
        try
        {
            _airlineService.UpdateAirline(airlineId, airlineDTO);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            // Логирование ошибки
            return BadRequest(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (NotFoundException ex)
        {
            // Логирование ошибки
            return NotFound(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (Exception ex)
        {
            // Логирование ошибки
            return StatusCode(500, "Internal server error"); // Вернуть статус код 500 с общим сообщением об ошибке
        }
    }

    [HttpDelete("DeleteAirline")]
    public IActionResult DeleteAirline([FromQuery] string airlineId)
    {
        try
        {
            _airlineService.DeleteAirline(airlineId); 
            return Ok();
        }
        catch (ArgumentException ex)
        {
            // Логирование ошибки
            return BadRequest(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (NotFoundException ex)
        {
            // Логирование ошибки
            return NotFound(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (Exception ex)
        {
            // Логирование ошибки
            return StatusCode(500, "Internal server error"); // Вернуть статус код 500 с общим сообщением об ошибке
        }
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
    public IActionResult AddTicket([FromBody] TicketDTO ticketDTO)
    {
        try
        {
            var ticketID = _ticketService.AddTicket(ticketDTO);
            return Ok(ticketID);
        }
        catch (ArgumentException ex)
        {
            // Логирование ошибки
            return BadRequest(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (Exception ex)
        {
            // Логирование ошибки
            return StatusCode(500, "Internal server error"); // Вернуть статус код 500 с общим сообщением об ошибке
        }
    }

    [HttpPut("UpdateTicket")]
    public IActionResult UpdateTicket([FromQuery] string ticketId, [FromBody] TicketDTO ticketDTO)
    {   
        try
        {
            _ticketService.UpdateTicket(ticketId, ticketDTO);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            // Логирование ошибки
            return BadRequest(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (NotFoundException ex)
        {
            // Логирование ошибки
            return NotFound(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (Exception ex)
        {
            // Логирование ошибки
            return StatusCode(500, "Internal server error"); // Вернуть статус код 500 с общим сообщением об ошибке
        }
    }

    [HttpDelete("DeleteTicket")]
    public IActionResult DeleteTicket([FromQuery] string ticketId)
    {
        try
        {
            _ticketService.DeleteTicket(ticketId);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            // Логирование ошибки
            return BadRequest(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (NotFoundException ex)
        {
            // Логирование ошибки
            return NotFound(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (Exception ex)
        {
            // Логирование ошибки
            return StatusCode(500, "Internal server error"); // Вернуть статус код 500 с общим сообщением об ошибке
        }
    }
    
    //Flights
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
    public IActionResult AddFlight([FromBody] FlightDTO flightDTO)
    {
        try
        {
            var flightID = _flightService.AddFlight(flightDTO);
            return Ok(flightID);
        }
        catch (ArgumentException ex)
        {
            // Логирование ошибки
            return BadRequest(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (Exception ex)
        {
            // Логирование ошибки
            return StatusCode(500, "Internal server error"); // Вернуть статус код 500 с общим сообщением об ошибке
        }
    }

    [HttpPut("UpdateFlight")]
    public IActionResult UpdateFlight([FromQuery] string flightId, [FromBody] FlightDTO flightDTO)
    {
        try
        {
            _flightService.UpdateFlight(flightId, flightDTO);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            // Логирование ошибки
            return BadRequest(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (NotFoundException ex)
        {
            // Логирование ошибки
            return NotFound(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (Exception ex)
        {
            // Логирование ошибки
            return StatusCode(500, "Internal server error"); // Вернуть статус код 500 с общим сообщением об ошибке
        }
    }

    [HttpDelete("DeleteFlight")]
    public IActionResult DeleteFlight([FromQuery] string flightId)
    {
        try
        {
            _flightService.DeleteFlight(flightId);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            // Логирование ошибки
            return BadRequest(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (NotFoundException ex)
        {
            // Логирование ошибки
            return NotFound(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (Exception ex)
        {
            // Логирование ошибки
            return StatusCode(500, "Internal server error"); // Вернуть статус код 500 с общим сообщением об ошибке
        }
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
    public IActionResult AddDestination([FromBody] DestinationDTO destinationDTO)
    {
        try
        {    
            var destinationID = _destinationService.AddDestination(destinationDTO);
            return Ok(destinationID);
        }
        catch (ArgumentException ex)
        {
            // Логирование ошибки
            return BadRequest(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (Exception ex)
        {
            // Логирование ошибки
            return StatusCode(500, $"Internal server error, {ex.Message}"); // Вернуть статус код 500 с общим сообщением об ошибке
        }
    }
    
    [HttpPut("UpdateDestination")]
    public IActionResult UpdateDestination([FromQuery] string destinationId, [FromBody] DestinationDTO destinationDTO)
    {
        try
        {
            _destinationService.UpdateDestination(destinationId, destinationDTO);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            // Логирование ошибки
            return BadRequest(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (NotFoundException ex)
        {
            // Логирование ошибки
            return NotFound(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (Exception ex)
        {
            // Логирование ошибки
            return StatusCode(500, "Internal server error"); // Вернуть статус код 500 с общим сообщением об ошибке
        }
    }

    [HttpDelete("DeleteDestination")]
    public IActionResult DeleteDestination([FromQuery] string destinationId)
    {
        try
        {
            _destinationService.DeleteDestination(destinationId);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            // Логирование ошибки
            return BadRequest(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (NotFoundException ex)
        {
            // Логирование ошибки
            return NotFound(ex.Message); // Отправить сообщение об ошибке клиенту
        }
        catch (Exception ex)
        {
            // Логирование ошибки
            return StatusCode(500, "Internal server error"); // Вернуть статус код 500 с общим сообщением об ошибке
        }
    }
}