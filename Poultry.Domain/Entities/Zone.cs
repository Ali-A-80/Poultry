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

        public LightingStatus LightingStatus { get; set; }

        public ICollection<TemperatureSensor> TemperatureSensors { get; set; }
        public ICollection<HumiditySensor> HumiditySensors { get; set; }
        public ICollection<VentilationSensor> VentilationSensors { get; set; }

        public double GetAverageTemperatureSensorAmount()
        {
            if (TemperatureSensors == null || TemperatureSensors.Count == 0)
            {
                return 0;
            }

            double totalAmount = TemperatureSensors.Sum(sensor => sensor.Amount);
            return totalAmount / TemperatureSensors.Count;
        }

        public double GetAverageHumiditySensorAmount()
        {
            if (HumiditySensors == null || HumiditySensors.Count == 0)
            {
                return 0;
            }

            double totalAmount = HumiditySensors.Sum(sensor => sensor.Amount);
            return totalAmount / HumiditySensors.Count;
        }

        public double GetAverageVentilationSensorAmount()
        {
            if (VentilationSensors == null || VentilationSensors.Count == 0)
            {
                return 0;
            }

            double totalAmount = VentilationSensors.Sum(sensor => sensor.AirFlow);
            return totalAmount / VentilationSensors.Count;
        }

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
