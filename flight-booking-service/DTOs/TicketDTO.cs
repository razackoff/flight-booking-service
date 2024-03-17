namespace flight_booking_service.DTOs;

public class TicketDTO
{
    public string FlightId { get; set; } // Идентификатор рейса
    public string UserId { get; set; } // Идентификатор пользователя
    public string ServiceClass { get; set; } // Класс обслуживания (эконом, бизнес, первый класс)
    public decimal Price { get; set; } // Стоимость билета
    public string AdditionalInfo { get; set; } // Дополнительные данные о билете
}