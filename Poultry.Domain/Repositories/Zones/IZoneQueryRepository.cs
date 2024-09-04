using Poultry.Domain.Entities;

namespace Poultry.Domain.Repositories.Zones;

public interface IZoneQueryRepository
{
    IQueryable<Zone> GetAll();
}
