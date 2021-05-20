using MeterCharge.ApplicationCore.Entities;
using MeterCharge.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MeterCharge.Infrastructure
{
    public class MeterChargeSaver : IMeterChargeSaver
    {
        public void CalculateChargeForMeterReadingsAndSave(IEnumerable<Meter> meters)
        {
            var location = @"C:\MeterDb\";
            if (!Directory.Exists(location))
            {
                Directory.CreateDirectory(location);
            }
            foreach (var meter in meters)
            {
               
                var filename = "Meter-" + meter.Id + ".log";
                StreamWriter writer = File.AppendText(location + filename);
                writer.Write("Timestamp".PadRight(20, ' ') + "\t" + "Meter Type".PadRight(15, ' ') + "\t" + "Consumption".PadRight(15, ' ') + "\t" + "Cost".PadRight(15, ' ') + "\t" + "Charge".PadRight(15, ' ') + "\t" + Environment.NewLine);
                writer.AutoFlush = true;

                foreach (var reading in meter.Readings)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                    sb.Append("\t");
                    sb.Append(meter.MeterType.Name.PadRight(15, ' '));
                    sb.Append("\t");
                    sb.Append(reading.ToString().PadRight(15, ' '));
                    sb.Append("\t");
                    sb.Append(meter.GetCost().ToString().PadRight(15, ' '));
                    sb.Append("\t");
                    sb.Append(meter.CalculateCharge(reading).ToString().PadRight(15, ' '));
                    sb.Append("\t");
                    sb.Append(Environment.NewLine);

                    writer.Write(sb.ToString());
                }
            }
        }
    }
}
