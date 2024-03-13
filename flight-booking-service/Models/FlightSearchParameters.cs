namespace flight_booking_service.Models;

public class FlightSearchParameters
{
    public string DepartureAirport { get; set; }
    public string DestinationAirport { get; set; }
    public DateTime DepartureDate { get; set; }
}