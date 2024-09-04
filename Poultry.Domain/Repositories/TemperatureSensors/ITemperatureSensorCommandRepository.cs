using Poultry.Domain.Entities;

namespace Poultry.Domain.Repositories.TemperatureSensors;

public interface ITemperatureSensorCommandRepository
{
    Task<bool> TemperatureSensorExists(long id, CancellationToken cancellationToken);

    Task<TemperatureSensor> GetById(long temperatureSensor, CancellationToken cancellationToken);

    Task AddTemperatureSensor(TemperatureSensor temperatureSensor, CancellationToken cancellationToken);

    Task UpdateTemperatureSensor(TemperatureSensor temperatureSensor, CancellationToken cancellationToken);
}
