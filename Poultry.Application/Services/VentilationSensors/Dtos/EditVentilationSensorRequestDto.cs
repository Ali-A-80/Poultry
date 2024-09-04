using Poultry.Domain.Entities;

namespace Poultry.Application.Services.VentilationSensors.Dtos
{
    public class EditVentilationSensorRequestDto
    {
        public long Id { get; set; }
        public VentilationStatus VentilationStatus { get; set; }
        public float AirFlow { get; set; }
    }
}
