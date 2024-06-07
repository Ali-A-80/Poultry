namespace Poultry.Persistance.Repositories.Zones
{
    public interface IZoneCommandRepository
    {
        Task<bool> ZoneExists(long zoneId, CancellationToken cancellationToken);
    }
}
