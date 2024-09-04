using Poultry.Domain.Entities;

namespace Poultry.Domain.Repositories.VentilationSensors;

public interface IVentilationSensorCommandRepository
{
    Task<bool> VentilationSensorExists(long ventilationSensorId, CancellationToken cancellationToken);

    Task AddVentilationSensor(VentilationSensor entity, CancellationToken cancellationToken);

    Task UpdateVentilationSensor(VentilationSensor entity, CancellationToken cancellationToken);

    Task<VentilationSensor> GetById(long ventilationSensorId, CancellationToken cancellationToken);
}
