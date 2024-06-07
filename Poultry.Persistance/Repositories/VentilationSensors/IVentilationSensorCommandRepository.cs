namespace Poultry.Persistance.Repositories.VentilationSensors
{
    public interface IVentilationSensorCommandRepository
    {
        Task<bool> VentilationSensorExists(long ventilationSensorId, CancellationToken cancellationToken);
    }
}
