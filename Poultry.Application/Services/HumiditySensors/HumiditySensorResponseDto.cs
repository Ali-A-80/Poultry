using Poultry.Domain.Entities;

namespace Poultry.Application.Services.HumiditySensors
{
    public class HumiditySensorResponseDto
    {
        public HumiditySensorResponseDto(HumiditySensor humiditySensor)
        {
            HumidityStatus = humiditySensor.HumidityStatus;
            Amount = humiditySensor.Amount;
        }

        public HumidityStatus HumidityStatus { get; set; }
        public int Amount { get; set; }
    }
}
