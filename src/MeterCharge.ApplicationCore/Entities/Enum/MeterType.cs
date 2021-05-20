using Ardalis.SmartEnum;

namespace MeterCharge.ApplicationCore.Entities.Enum
{
    public abstract class MeterType : SmartEnum<MeterType>
    {
        public static readonly MeterType Electricity = new ElectricityMeterType();
        public static readonly MeterType Water = new WaterMeterType();
        public static readonly MeterType Heating = new HeatingMeterType();

        private MeterType(string name, int value) : base(name, value)
        {

        }

        public int Cost { get; private set; }

        private sealed class ElectricityMeterType : MeterType
        {
            public ElectricityMeterType() : base("Electricity", 1)
            {
                Cost = 4;
            }
        }

        private sealed class WaterMeterType : MeterType
        {
            public WaterMeterType() : base("Water", 2)
            {
                Cost = 3;
            }
        }

        private sealed class HeatingMeterType : MeterType
        {
            public HeatingMeterType() : base("Heating", 3)
            {
                Cost = 5;
            }
        }
    }
}
