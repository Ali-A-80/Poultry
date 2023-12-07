using Poultry.Domain.Entities;

namespace Poultry.Application.Services.TemperatureSensors
{
    public class TemperatureSensorRequestDto
    {
        public long? Id { get; set; }
        public TemperatureStatus TemperatureStatus { get; set; }
        public int Amount { get; set; }

        public long ZoneId { get; set; }
    }
}
