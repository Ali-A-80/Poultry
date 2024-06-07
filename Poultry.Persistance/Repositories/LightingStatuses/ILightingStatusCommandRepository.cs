namespace Poultry.Persistance.Repositories.LightingStatuses
{
    public interface ILightingStatusCommandRepository
    {
        Task<bool> LightingStatusExists(long lightingStatusId, CancellationToken cancellationToken);
    }
}
