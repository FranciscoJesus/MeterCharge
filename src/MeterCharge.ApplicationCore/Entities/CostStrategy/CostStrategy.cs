using Ardalis.GuardClauses;
using MeterCharge.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterCharge.ApplicationCore.Entities.CostStrategy
{
    public abstract class CostStrategy : ICostStrategy
    {
        protected readonly IDateService _dateService;

        public CostStrategy(IDateService dateService)
        {
            Guard.Against.Null(dateService, nameof(dateService));
            _dateService = dateService;
        }
        public abstract int GetCharge(int cost, int consumption);

        public abstract int GetCost(int cost);
    }
}
