namespace flight_booking_service.Models;

public class Ticket
{
    public string Id { get; set; } // Идентификатор билета
    public string FlightId { get; set; } // Идентификатор рейса
    public string UserId { get; set; } // Идентификатор пользователя
    public string ServiceClass { get; set; } // Класс обслуживания (эконом, бизнес, первый класс)
    public decimal Price { get; set; } // Стоимость билета
    public string AdditionalInfo { get; set; } // Дополнительные данные о билете

    // Конструктор для создания нового билета
    public Ticket()
    {
        // Дополнительная инициализация по желанию
    }
}