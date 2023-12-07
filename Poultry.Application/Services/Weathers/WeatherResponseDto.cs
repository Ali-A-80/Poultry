using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Weathers
{
    public class WeatherResponseDto
    {
        public WeatherResponseDto(Weather weather)
        {
            ZoneId = weather.ZoneId;
        }

        public long ZoneId { get; set; }
    }
}
