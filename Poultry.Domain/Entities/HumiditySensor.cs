namespace Poultry.Domain.Entities
{
    public class HumiditySensor : BaseEntity
    {

        public HumidityStatus HumidityStatus { get;set; }
        public int Amount { get; set; }

        public long ZoneId { get; set; }
        public Zone Zone { get; set; }

    }


    #region HumidityStatusEnum
    public enum HumidityStatus : byte
    {
        slow = 0, normal, high
    }

    #endregion
}
