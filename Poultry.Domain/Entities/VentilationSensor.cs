namespace Poultry.Domain.Entities
{
    public class VentilationSensor : BaseEntity
    {

        public VentilationStatus VentilationStatus { get; set; }
        public float AirFlow { get; set; }

        public long ZoneId { get;set; }
        public Zone Zone { get; set; }


    }

    #region VentilationStatusEnum
    public enum VentilationStatus : byte
    {
        off = 0, slow, normal, fast
    }

    #endregion
}
