using MeterCharge.ApplicationCore.Interfaces;
using System;

namespace MeterCharge.ApplicationCore.Services
{
    public class DateService : IDateService
    {
        public bool IsNight()
        {
            return DateTime.Now.TimeOfDay.Hours < 8 || DateTime.Now.TimeOfDay.Hours > 20;
        }
    }
}
