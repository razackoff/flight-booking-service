using flight_booking_service.Models;

namespace flight_booking_service.DTOs;

public class DestinationDTO
{
    public string Name { get; set; } // Название места назначения
    public string Code { get; set; } // Код места назначения (например, IATA код)
    public CoordinatesDTO CoordinatesDTO { get; set; } // Географические координаты
    public string AdditionalInfo { get; set; } // Дополнительные данные о месте назначения

}