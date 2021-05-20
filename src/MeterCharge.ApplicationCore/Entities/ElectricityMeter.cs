using System;
using System.Collections.Generic;
using MeterCharge.ApplicationCore.Entities.CostStrategy;
using MeterCharge.ApplicationCore.Entities.Enum;
using MeterCharge.ApplicationCore.Interfaces;

namespace MeterCharge.ApplicationCore.Entities
{
    public class ElectricityMeter : Meter
    {
        public ElectricityMeter(string id,
                                IEnumerable<int> readings,
                                IDateService dateService) : base(id, readings)
        {
            this.MeterType = MeterType.Electricity;
            SetCostStrategy(new NightHalfPriceCostStrategy(dateService));
        }
    }
}
