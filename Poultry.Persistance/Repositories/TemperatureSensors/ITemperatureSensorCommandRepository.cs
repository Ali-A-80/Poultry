namespace Poultry.Persistance.Repositories.TemperatureSensors
{
    public interface ITemperatureSensorCommandRepository
    {
        Task<bool> TemperatureSensorExists(long id, CancellationToken cancellationToken);
    }
}
