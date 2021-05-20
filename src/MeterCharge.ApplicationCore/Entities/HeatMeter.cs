using MeterCharge.ApplicationCore.Entities.CostStrategy;
using MeterCharge.ApplicationCore.Entities.Enum;
using MeterCharge.ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace MeterCharge.ApplicationCore.Entities
{
    public class HeatMeter : Meter
    {
        public HeatMeter(string id,
                         IEnumerable<int> readings,
                         IDateService dateService) : base(id, readings)
        {
            this.MeterType = MeterType.Heating;
            SetCostStrategy(new NormalCostStrategy(dateService));
        }
    }
}
