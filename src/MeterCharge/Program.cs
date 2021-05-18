using System;
using System.Collections.Generic;

namespace MeterCharge
{
  class Program
  {
    static void Main(string[] args)
    {
      var m1 = new Meter { Id = Guid.NewGuid().ToString(), MeterType = MeterType.Electricity, Readings = new List<int> { 97,50 } };
      var m2 = new Meter { Id = Guid.NewGuid().ToString(), MeterType = MeterType.Heating, Readings = new List<int> { 55, 87 } };
      var m3 = new Meter { Id = Guid.NewGuid().ToString(), MeterType = MeterType.Water, Readings = new List<int> { 98, 86 } };

      var list1 = new List<Meter>{m1,m2,m3};
      new MeterChargeSaver().CalculateChargeForMeterReadingsAndSave(list1);
    }
  }
}