using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterCharge.ApplicationCore.Entities.CostStrategy
{
    public interface ICostStrategy
    {
        int GetCharge(int cost,int consumption);

        int GetCost(int cost);
    }
}
