using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MeterCharge
{
  // We are not sure if we want to save meterdata to text files going forward.
  public class MeterChargeSaver
  {
    public void CalculateChargeForMeterReadingsAndSave(IEnumerable<Meter> meters)
    {
      foreach (var meter in meters)
      {
        if (!Directory.Exists(@"C:\MeterDb\"))
        {
          Directory.CreateDirectory(@"C:\MeterDb\");
        }
        var filename = "Meter" + meter.Id + ".log";
        StreamWriter writer = File.AppendText(@"C:\MeterDb\" + filename);
        writer.Write("Timestamp".PadRight(20, ' ') + "\t" + "Meter Type".PadRight(15, ' ') + "\t" + "Consumption".PadRight(15, ' ') + "\t" + "Cost".PadRight(15, ' ') + "\t" + "Charge".PadRight(15, ' ') + "\t" + Environment.NewLine);
        writer.AutoFlush = true;

        foreach (var reading in meter.Readings)
        {
          int cost = 0;
          if (meter.MeterType == MeterType.Electricity)
          {
            if (DateTime.Now.TimeOfDay.Hours < 8 || DateTime.Now.TimeOfDay.Hours > 20)
            {
              // half price at off peak hours: before 8 and after 20.
              cost = 2;
            }
            else
            {
              cost = 4;
            }
          }
          else if (meter.MeterType == MeterType.Heating)
          {
            cost = 5;
          }
          else if (meter.MeterType == MeterType.Water)
          {
            cost = 3;
          }
          var charge = cost * reading;
          StringBuilder sb = new StringBuilder();
          sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
          sb.Append("\t");
          sb.Append(meter.MeterType.ToString().PadRight(15, ' '));
          sb.Append("\t");
          sb.Append(reading.ToString().PadRight(15, ' '));
          sb.Append("\t");
          sb.Append(cost.ToString().PadRight(15, ' '));
          sb.Append("\t");
          sb.Append(charge.ToString().PadRight(15, ' '));
          sb.Append("\t");
          sb.Append(Environment.NewLine);

          writer.Write(sb.ToString());
        }
      }
    }
  }
}
