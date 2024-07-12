using Poultry.Domain.Entities;

namespace Poultry.Domain.Repositories.VentilationSensors;

public interface IVentilationSensorQueryRepository
{
    IQueryable<VentilationSensor> GetAll();
}
