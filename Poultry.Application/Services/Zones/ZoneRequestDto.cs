using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Zones
{
    public class ZoneRequestDto
    {
        public long? Id { get; set; }
        public ZoneType ZoneType { get; set; }

    }
}
