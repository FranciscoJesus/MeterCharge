using Ardalis.GuardClauses;
using MeterCharge.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterCharge.ApplicationCore.Entities.CostStrategy
{
    public class NightHalfPriceCostStrategy : CostStrategy
    {
        public NightHalfPriceCostStrategy(IDateService dateService) : base(dateService)
        {

        }
        public override int GetCharge(int cost, int consumption)
        {
            Guard.Against.Negative(cost, nameof(cost));
            Guard.Against.Negative(consumption, nameof(consumption));

            return GetCost(cost) * consumption;
        }

        public override int GetCost(int cost)
        {
            Guard.Against.Negative(cost, nameof(cost));

            var discount = _dateService.IsNight() ? 2 : 1;
            return cost / discount;
        }
    }
}
