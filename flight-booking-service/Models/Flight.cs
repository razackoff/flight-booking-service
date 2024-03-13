namespace flight_booking_service.Models;

public class Flight
{
    public string Id { get; set; }
    public string DepartureLocation { get; set; } // Место отправления
    public string Destination { get; set; } // Место назначения
    public DateTime DepartureDateTime { get; set; } // Дата и время вылета
    public DateTime ArrivalDateTime { get; set; } // Дата и время прилета
    public int AvailableEconomySeats { get; set; } // Доступные места в эконом-классе
    public int AvailableBusinessSeats { get; set; } // Доступные места в бизнес-классе
    public int AvailableFirstClassSeats { get; set; } // Доступные места в первом классе
    public decimal EconomyClassPrice { get; set; } // Стоимость билета в эконом-классе
    public decimal BusinessClassPrice { get; set; } // Стоимость билета в бизнес-классе
    public decimal FirstClassPrice { get; set; } // Стоимость билета в первом классе
    public string AirlineId { get; set; } // Авиакомпания
    public string AircraftType { get; set; } // Тип самолета
    // Дополнительные поля о рейсе...

    // Конструктор для создания нового рейса
    public Flight()
    {
        AvailableEconomySeats = 0;
        AvailableBusinessSeats = 0;
        AvailableFirstClassSeats = 0;
    }
}