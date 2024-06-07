using Poultry.Domain.Entities;

namespace Poultry.Application.Services.HealthStatuses.Dtos
{
    public class EditHealthStatusRequestDto
    {
        public long Id { get; set; }
        public byte BodyTemprature { get; set; }
        public HealthLevel HealthLevel { get; set; }
        public DateTime CheckupDate { get; set; }
    }
}
