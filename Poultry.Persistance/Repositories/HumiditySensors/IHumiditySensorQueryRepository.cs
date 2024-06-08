using Poultry.Domain.Entities;

namespace Poultry.Persistance.Repositories.HumiditySensors;

public interface IHumiditySensorQueryRepository
{
    IQueryable<HumiditySensor> GetAll();
}
