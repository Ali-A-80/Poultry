using Poultry.Domain.Entities;

namespace Poultry.Application.Services.LightingStatuses
{
    public class LightingStatusRequestDto
    {
        public long? Id { get; set; }
        public LightingStatusType LightingStatusType { get; set; }
        public int Amount { get; set; }
    }
}
