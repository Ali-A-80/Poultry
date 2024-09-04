using Poultry.Domain.Entities;

namespace Poultry.Application.Services.TemperatureSensors.Dtos
{
    public class EditTemperatureSensorRequestDto
    {
        public long Id { get; set; }
        public TemperatureStatus TemperatureStatus { get; set; }
        public int Amount { get; set; }
    }
}
