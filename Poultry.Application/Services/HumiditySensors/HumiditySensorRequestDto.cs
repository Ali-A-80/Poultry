using Poultry.Domain.Entities;

namespace Poultry.Application.Services.HumiditySensors
{
    public class HumiditySensorRequestDto
    {
        public long? Id { get; set; }
        public HumidityStatus HumidityStatus { get; set; }
        public int Amount { get; set; }
        public long ZoneId { get; set; }
    }
}
