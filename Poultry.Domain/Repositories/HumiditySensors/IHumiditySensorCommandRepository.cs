using Poultry.Domain.Entities;

namespace Poultry.Domain.Repositories.HumiditySensors;

public interface IHumiditySensorCommandRepository
{
    Task<bool> HumiditySensorExists(long humiditySensorId, CancellationToken cancellationToken);

    Task AddHumiditySensor(HumiditySensor entity, CancellationToken cancellationToken);

    Task UpdateHumiditySensor(HumiditySensor entity, CancellationToken cancellationToken);

    Task<HumiditySensor> GetById(long humiditySensorId, CancellationToken cancellationToken);
}
