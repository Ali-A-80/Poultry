using Poultry.Domain.Entities;

namespace Poultry.Application.Services.VentilationSensors.Dtos
{
    public class CreateVentilationSensorRequestDto
    {
        public VentilationStatus VentilationStatus { get; set; }
        public float AirFlow { get; set; }

        public long ZoneId { get; set; }
    }
}
