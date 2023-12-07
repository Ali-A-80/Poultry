using Poultry.Domain.Entities;

namespace Poultry.Application.Services.TemperatureSensors
{
    public class TemperatureSensorResponseDto
    {
        public TemperatureSensorResponseDto(TemperatureSensor temperatureSensor)
        {
            TemperatureStatus = temperatureSensor.TemperatureStatus;
            Amount = temperatureSensor.Amount;
        }

        public TemperatureStatus TemperatureStatus { get; set; }
        public int Amount { get; set; }
    }
}
