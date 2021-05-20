using MeterCharge.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterCharge.ApplicationCore.Entities.CostStrategy
{
    public class NormalCostStrategy : CostStrategy
    {
        public NormalCostStrategy(IDateService dateService) : base (dateService)
        {

        }
        public override int GetCharge(int cost, int consumption)
        {
            return cost * consumption;
        }

        public override int GetCost(int cost)
        {
            return cost;
        }
    }
}
