using Ardalis.GuardClauses;
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

        protected ICostStrategy _costStrategy;

        public Meter(string id, IEnumerable<int> readings)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));
            Guard.Against.Null(readings, nameof(readings));
            foreach(var reading in readings)
            {
                Guard.Against.Negative(reading, nameof(reading));
            }

            Id = id;
            Readings = readings;
        }

        public int CalculateCharge(int consumption)
        {
            Guard.Against.Negative(consumption, nameof(consumption));
            return _costStrategy.GetCharge(this.MeterType.Cost, consumption);
        }

        public int GetCost()
        {
            return _costStrategy.GetCost(MeterType.Cost);
        }

        protected void SetCostStrategy(ICostStrategy costStrategy)
        {
            _costStrategy = costStrategy;
        }
    }
}
