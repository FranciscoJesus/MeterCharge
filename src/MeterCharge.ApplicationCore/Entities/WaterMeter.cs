using System;
using System.Collections.Generic;
using MeterCharge.ApplicationCore.Entities.CostStrategy;
using MeterCharge.ApplicationCore.Entities.Enum;
using MeterCharge.ApplicationCore.Interfaces;

namespace MeterCharge.ApplicationCore.Entities
{
    public class WaterMeter : Meter
    {
        public WaterMeter(string id,
                         IEnumerable<int> readings,
                         IDateService dateService) : base(id, readings)
        {
            this.MeterType = MeterType.Water;
            SetCostStrategy(new NormalCostStrategy(dateService));
        }
    }
}
