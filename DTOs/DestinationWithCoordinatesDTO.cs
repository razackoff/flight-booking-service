using flight_booking_service.Models;

namespace flight_booking_service.DTOs;

public class DestinationWithCoordinatesDTO
{
    public string Id { get; set; } // Идентификатор места назначения
    public string Name { get; set; } // Название места назначения
    public string Code { get; set; } // Код места назначения (например, IATA код)
    public Coordinates Coordinates { get; set; } // Географические координаты
    public string AdditionalInfo { get; set; } // Дополнительные данные о месте назначения
}