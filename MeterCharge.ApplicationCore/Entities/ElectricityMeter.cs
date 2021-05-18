using System;
using System.Collections.Generic;
using MeterCharge.ApplicationCore.Entities.CostStrategy;
using MeterCharge.ApplicationCore.Entities.Enum;

namespace MeterCharge.ApplicationCore.Entities
{
    public class ElectricityMeter : Meter
    {
        public ElectricityMeter(string id,
                                IEnumerable<int> readings,
                                ICostStrategy costStrategy) : base(id, readings, costStrategy)
        {
            this.MeterType = MeterType.Electricity;
        }
    }
}
