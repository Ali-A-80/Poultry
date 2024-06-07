using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Zones.Dtos
{
    public class EditZoneRequestDto
    {
        public long Id { get; set; }
        public ZoneType ZoneType { get; set; }

    }
}
