using Poultry.Domain.Entities;

namespace Poultry.Domain.Repositories.LightingStatuses;

public interface ILightingStatusQueryRepository
{
    IQueryable<LightingStatus> GetAll();
}
