using Poultry.Domain.Entities;

namespace Poultry.Persistance.Repositories.TemperatureSensors;

public interface ITemperatureSensorQueryRepository
{
    IQueryable<TemperatureSensor> GetAll();
}
