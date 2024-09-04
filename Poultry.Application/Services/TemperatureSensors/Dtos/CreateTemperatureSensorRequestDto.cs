using Poultry.Domain.Entities;

namespace Poultry.Application.Services.TemperatureSensors.Dtos
{
    public class CreateTemperatureSensorRequestDto
    {
        public TemperatureStatus TemperatureStatus { get; set; }
        public int Amount { get; set; }

        public long ZoneId { get; set; }
    }
}
