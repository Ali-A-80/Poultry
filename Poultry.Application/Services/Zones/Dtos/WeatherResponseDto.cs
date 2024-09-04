using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Zones.Dtos
{
    public class WeatherResponseDto
    {
        public WeatherResponseDto(WeatherDto weather)
        {
            AverageTemperature = weather.AverageTemperature;
            AverageHumidity = weather.AverageHumidity;
            AverageVentilation = weather.AverageVentilation;
        }
        public double AverageTemperature { get; set; }
        public double AverageHumidity { get; set; }
        public double AverageVentilation { get; set; }
    }
}
