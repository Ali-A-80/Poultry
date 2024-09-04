using Poultry.Domain.Entities;

namespace Poultry.Domain.Repositories.TemperatureSensors;

public interface ITemperatureSensorQueryRepository
{
    IQueryable<TemperatureSensor> GetAll();
}
