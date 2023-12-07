using Poultry.Domain.Entities;

namespace Poultry.Application.Services.VentilationSensors
{
    public class VentilationSensorRequestDto
    {
        public long? Id { get; set; }
        public VentilationStatus VentilationStatus { get; set; }
        public float AirFlow { get; set; }

        public long ZoneId { get; set; }
    }
}
