using Poultry.Domain.Entities;

namespace Poultry.Application.Services.HealthStatuses
{
    public class HealthStatusResponseDto
    {
        public HealthStatusResponseDto(HealthStatus healthStatus)
        {
            BodyTemprature = healthStatus.BodyTemprature;
            HealthLevel = healthStatus.HealthLevel;
            CheckupDate = healthStatus.CheckupDate;
        }

        public int BodyTemprature { get; set; }
        public HealthLevel HealthLevel { get; set; }
        public DateTime CheckupDate { get; set; }
    }
}
