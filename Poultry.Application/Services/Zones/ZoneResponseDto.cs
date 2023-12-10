using Poultry.Application.Services.LightingStatuses;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Zones
{
    public class ZoneResponseDto
    {
        public ZoneResponseDto(Zone zone)
        {
            ZoneType = zone.ZoneType;
            LightingStatus = new LightingStatusResponseDto(zone.LightingStatus);
            Weather = new WeatherResponseDto(new WeatherDto
            {
                AverageHumidity = zone.GetAverageHumiditySensorAmount(),
                AverageTemperature = zone.GetAverageTemperatureSensorAmount(),
                AverageVentilation = zone.GetAverageVentilationSensorAmount()
            });
        }

        public ZoneType ZoneType { get; set; }
        public LightingStatusResponseDto LightingStatus { get; set; }
        public WeatherResponseDto Weather { get; set; }

        
    }
}
