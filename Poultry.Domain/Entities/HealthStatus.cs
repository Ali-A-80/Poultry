namespace Poultry.Domain.Entities
{
    public class HealthStatus : BaseEntity
    {

        public int BodyTemprature { get; set; }
        public HealthLevel HealthLevel { get; set; }
        public DateTime CheckupDate { get; set; }

        public long ChickenId { get; set; }
        public Chicken Chicken { get; set; }

    }

    #region HEALTHLEVELENUM
    public enum HealthLevel : byte
    {
        Healthy = 0,
        Sick,
        Critical
    }

    #endregion
}
