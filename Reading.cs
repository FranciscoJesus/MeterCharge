using System.Collections.Generic;

namespace MeterCharge
{
  public enum MeterType
  {
    Electricity,
    Water,
    Heating
  }

  public class Meter
  {
    public string Id { get; set; }
    public MeterType MeterType { get; set; }
    public IEnumerable<int> Readings { get; set; }
  }
}