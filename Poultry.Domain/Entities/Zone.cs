namespace Poultry.Domain.Entities
{
    public class Zone : BaseEntity
    {
        public Zone()
        {
            TemperatureSensors = new HashSet<TemperatureSensor>();
            HumiditySensors = new HashSet<HumiditySensor>();
            VentilationSensors = new HashSet<VentilationSensor>();
        }

        public ZoneType ZoneType { get; set; }
        public Weather Weather { get; set; }

        public LightingStatus LightingStatus { get; set; }

        public ICollection<TemperatureSensor> TemperatureSensors { get; set; }
        public ICollection<HumiditySensor> HumiditySensors { get; set; }
        public ICollection<VentilationSensor> VentilationSensors { get; set; }


    }

    #region ZoneTypeEnum
    public enum ZoneType : byte
    {
        Feed = 0,
        LayingArea,
        health
    }

    #endregion
}
