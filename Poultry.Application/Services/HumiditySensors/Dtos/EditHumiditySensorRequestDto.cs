using Poultry.Domain.Entities;

namespace Poultry.Application.Services.HumiditySensors.Dtos
{
    public class EditHumiditySensorRequestDto
    {
        public long Id { get; set; }
        public HumidityStatus HumidityStatus { get; set; }
        public int Amount { get; set; }
    }
}
