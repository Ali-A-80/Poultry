using Poultry.Domain.Entities;

namespace Poultry.Application.Services.HumiditySensors.Dtos
{
    public class CreateHumiditySensorRequestDto
    {
        public HumidityStatus HumidityStatus { get; set; }
        public int Amount { get; set; }
        public long ZoneId { get; set; }
    }
}
