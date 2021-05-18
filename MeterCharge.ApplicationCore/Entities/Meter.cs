using MeterCharge.ApplicationCore.Entities.CostStrategy;
using MeterCharge.ApplicationCore.Entities.Enum;
using System.Collections.Generic;

namespace MeterCharge.ApplicationCore.Entities
{
    public abstract class Meter
    {
        public string Id { get; private set; }
        public MeterType MeterType { get; protected set; }
        public IEnumerable<int> Readings { get; private set; }
        private readonly ICostStrategy _costStrategy;

        public Meter(string id, IEnumerable<int> readings, ICostStrategy costStrategy)
        {
            Id = id;
            Readings = readings;
            _costStrategy = costStrategy;
        }

        public int CalculateCharge(int consumption)
        {
            return _costStrategy.GetCharge(this.MeterType.Cost, consumption);
        }

        public int GetCost()
        {
            return _costStrategy.GetCost(MeterType.Cost);
        }
    }
}
