namespace Poultry.Domain.Entities
{
    public class TemperatureSensor : BaseEntity
    {

        public TemperatureStatus TemperatureStatus { get; set; }
        public int Amount { get; set; }

        public long ZoneId { get; set; }
        public Zone Zone { get; set; }



    }


    #region TemperatureStatusEnum
    public enum TemperatureStatus : byte
    {
        low = 0, normal, high
    }

    #endregion
}
