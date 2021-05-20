using MeterCharge.ApplicationCore.Entities;
using MeterCharge.ApplicationCore.Entities.CostStrategy;
using MeterCharge.ApplicationCore.Interfaces;
using MeterCharge.ApplicationCore.Services;
using MeterCharge.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace MeterCharge.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IDateService, DateService>();
            serviceCollection.AddSingleton<IMeterChargeSaver, MeterChargeSaver>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var dateService = serviceProvider.GetService<IDateService>();
            var meterChargeSaver = serviceProvider.GetService<IMeterChargeSaver>();

            var m1 = new ElectricityMeter(Guid.NewGuid().ToString(), new List<int> { 97, 50 }, dateService);
            var m2 = new HeatMeter(Guid.NewGuid().ToString(), new List<int> { 55, 87 }, dateService);
            var m3 = new WaterMeter(Guid.NewGuid().ToString(), new List<int> { 98, 86 }, dateService);

            var list1 = new List<Meter> { m1, m2, m3 };
            meterChargeSaver.CalculateChargeForMeterReadingsAndSave(list1);
        }
    }
}
