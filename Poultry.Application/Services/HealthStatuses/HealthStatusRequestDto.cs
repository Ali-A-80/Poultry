using Poultry.Domain.Entities;

namespace Poultry.Application.Services.HealthStatuses
{
    public class HealthStatusRequestDto
    {
        public long? Id { get; set; }
        public byte BodyTemprature { get; set; }
        public HealthLevel HealthLevel { get; set; }
        public DateTime CheckupDate { get; set; }
    }
}
