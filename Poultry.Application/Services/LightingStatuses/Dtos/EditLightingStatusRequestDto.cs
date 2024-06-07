using Poultry.Domain.Entities;

namespace Poultry.Application.Services.LightingStatuses.Dtos
{
    public class EditLightingStatusRequestDto
    {
        public long Id { get; set; }
        public LightingStatusType LightingStatusType { get; set; }
        public int Amount { get; set; }
    }
}
