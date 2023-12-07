using Poultry.Domain.Entities;

namespace Poultry.Application.Services.LightingStatuses
{
    public class LightingStatusResponseDto
    {
        public LightingStatusResponseDto(LightingStatus lightingStatus)
        {
            LightingStatusType = lightingStatus.LightingStatusType;
            Amount = lightingStatus.Amount;
        }

        public LightingStatusType LightingStatusType { get; set; }
        public int Amount { get; set; }
    }
}
