namespace Poultry.Persistance.Repositories.HumiditySensors
{
    public interface IHumiditySensorCommandRepository
    {
        Task<bool> HumiditySensorExists(long humiditySensorId, CancellationToken cancellationToken);
    }
}
