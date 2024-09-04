using Poultry.Domain.Entities;

namespace Poultry.Domain.Repositories.HumiditySensors;

public interface IHumiditySensorQueryRepository
{
    IQueryable<HumiditySensor> GetAll();
}
