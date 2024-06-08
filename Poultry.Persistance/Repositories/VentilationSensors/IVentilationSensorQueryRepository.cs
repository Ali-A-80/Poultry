using Poultry.Domain.Entities;

namespace Poultry.Persistance.Repositories.VentilationSensors;

public interface IVentilationSensorQueryRepository
{
    IQueryable<VentilationSensor> GetAll();
}
