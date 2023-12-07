namespace Poultry.Domain.Entities
{
    public class LightingStatus : BaseEntity
    {

        public LightingStatusType LightingStatusType { get; set; }
        public int Amount { get; set; }

        public long ZoneId { get; set; }
        public Zone Zone { get; set; }

    }


    #region LightingStatusEnum
    public enum LightingStatusType : byte
    {
        off = 0, dim, normal, bright
    }

    #endregion
}
