namespace flight_booking_service.Models;

public class TicketBookingRequest
{
    public string UserId { get; set; }
    public string FlightId { get; set; }
    public int NumberOfSeats { get; set; }
}