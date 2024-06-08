using Poultry.Domain.Entities;

namespace Poultry.Persistance.Repositories.Zones;

public interface IZoneQueryRepository
{
    IQueryable<Zone> GetAll();
}
