using FluentAssertions;
using MeterCharge.ApplicationCore.Entities;
using MeterCharge.Test.DataInitializer;
using MeterCharge.Test.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MeterCharge.Test
{
    public class MeterTests : IClassFixture<MeterFixture>
    {
        private readonly MeterFixture _meterFixture;
        public MeterTests(MeterFixture meterFixture)
        {
            _meterFixture = meterFixture;
        }

        [Theory]
        [MemberData(nameof(MeterGenerator.GetMeters), parameters: 0, MemberType = typeof(MeterGenerator))]
        public void CalculateElectricityMeterAtDay(string id, IEnumerable<int> readings, IEnumerable<int> expectedCosts)
        {
            var electricityMeter = new ElectricityMeter(id, readings, _meterFixture.dateServiceIsNightFalse);

            var consumption = electricityMeter.Readings.ToList().Select(s => electricityMeter.CalculateCharge(s));
            consumption.Should().Equal(expectedCosts);
        }

        [Theory]
        [MemberData(nameof(MeterGenerator.GetMeters), parameters: 0, MemberType = typeof(MeterGenerator))]
        public void CalculateElectricityMeterAtNight(string id, IEnumerable<int> readings, IEnumerable<int> expectedCosts)
        {
            var electricityMeter = new ElectricityMeter(id, readings, _meterFixture.dateServiceIsNightTrue);

            var consumption = electricityMeter.Readings.ToList().Select(s => electricityMeter.CalculateCharge(s));
            consumption.Should().Equal(expectedCosts.ToList().Select(s => s / 2));
        }

        [Theory]
        [MemberData(nameof(MeterGenerator.GetMeters), parameters: 1, MemberType = typeof(MeterGenerator))]
        public void CalculateHeatingMeterAtDay(string id, IEnumerable<int> readings, IEnumerable<int> expectedCosts)
        {
            var heatMeter = new HeatMeter(id, readings, _meterFixture.dateServiceIsNightFalse);

            var consumption = heatMeter.Readings.ToList().Select(s => heatMeter.CalculateCharge(s));
            consumption.Should().Equal(expectedCosts);
        }

        [Theory]
        [MemberData(nameof(MeterGenerator.GetMeters), parameters: 1, MemberType = typeof(MeterGenerator))]
        public void CalculateHeatingMeterAtNight(string id, IEnumerable<int> readings, IEnumerable<int> expectedCosts)
        {
            var heatMeter = new HeatMeter(id, readings, _meterFixture.dateServiceIsNightTrue);

            var consumption = heatMeter.Readings.ToList().Select(s => heatMeter.CalculateCharge(s));
            consumption.Should().Equal(expectedCosts);
        }

        [Theory]
        [MemberData(nameof(MeterGenerator.GetMeters), parameters: 2, MemberType = typeof(MeterGenerator))]
        public void CalculateWaterMeterAtDay(string id, IEnumerable<int> readings, IEnumerable<int> expectedCosts)
        {
            var waterMeter = new WaterMeter(id, readings, _meterFixture.dateServiceIsNightFalse);

            var consumption = waterMeter.Readings.ToList().Select(s => waterMeter.CalculateCharge(s));
            consumption.Should().Equal(expectedCosts);
        }

        [Theory]
        [MemberData(nameof(MeterGenerator.GetMeters), parameters: 2, MemberType = typeof(MeterGenerator))]
        public void CalculateWaterMeterAtNight(string id, IEnumerable<int> readings, IEnumerable<int> expectedCosts)
        {
            var waterMeter = new WaterMeter(id, readings, _meterFixture.dateServiceIsNightTrue);

            var consumption = waterMeter.Readings.ToList().Select(s => waterMeter.CalculateCharge(s));
            consumption.Should().Equal(expectedCosts);
        }

        [Theory]
        [MemberData(nameof(MeterGenerator.BadInputs), MemberType = typeof(MeterGenerator))]
        public void ShouldThrowException(Type exceptionType,string id, IEnumerable<int> readings)
        {
            Assert.Throws(exceptionType, () =>new WaterMeter(id, readings, _meterFixture.dateServiceIsNightTrue));
        }

        [Theory]
        [MemberData(nameof(MeterGenerator.GetMeters), parameters: 2, MemberType = typeof(MeterGenerator))]
        public void NullDateServiceThrowException(string id, IEnumerable<int> readings, IEnumerable<int> expectedCosts)
        {
            Assert.Throws<ArgumentNullException>(() => new WaterMeter(id, readings, null));
        }
    }
}
