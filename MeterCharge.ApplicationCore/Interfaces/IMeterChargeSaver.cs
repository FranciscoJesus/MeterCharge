using MeterCharge.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterCharge.ApplicationCore.Interfaces
{
    public interface IMeterChargeSaver
    {
        public void CalculateChargeForMeterReadingsAndSave(IEnumerable<Meter> meters);
    }
}
