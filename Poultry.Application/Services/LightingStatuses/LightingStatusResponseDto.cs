using Poultry.Domain.Entities;

namespace Poultry.Application.Services.LightingStatuses
{
    public class LightingStatusResponseDto
    {
        public LightingStatusResponseDto(LightingStatus lightingStatus)
        {
            LightingStatusType = lightingStatus.LightingStatusType;
            Amount = lightingStatus.Amount;
            ZoneId = lightingStatus.ZoneId;
        }

        public LightingStatusType LightingStatusType { get; set; }
        public int Amount { get; set; }
        public long ZoneId { get; set; }
    }
}
