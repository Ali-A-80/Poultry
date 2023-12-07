using Poultry.Domain.Entities;

namespace Poultry.Application.Services.VentilationSensors
{
    public class VentilationSensorResponseDto
    {
        public VentilationSensorResponseDto(VentilationSensor ventilationSensor)
        {
            VentilationStatus = ventilationSensor.VentilationStatus;
            AirFlow = ventilationSensor.AirFlow;
        }

        public VentilationStatus VentilationStatus { get; set; }
        public float AirFlow { get; set; }
    }
}
