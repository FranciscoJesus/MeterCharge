using MeterCharge.ApplicationCore.Entities.Enum;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MeterCharge.Test.DataInitializer
{
    public static class MeterGenerator
    {
        public static IEnumerable<object[]> GetMeters(int position)
        {
            var list = new List<object[]>
            {
                new object[] {
                    Guid.NewGuid().ToString(),
                    new List<int>{97, 50},
                    new List<int>
                    {
                        97 * MeterType.Electricity.Cost,
                        50 * MeterType.Electricity.Cost
                    }
                },

                new object[]
                {
                    Guid.NewGuid().ToString(),
                    new List<int>{55, 87},
                    new List<int>
                    {
                        55 * MeterType.Heating.Cost,
                        87 * MeterType.Heating.Cost
                    }
                },

                new object[]
                {
                    Guid.NewGuid().ToString(),
                    new List<int>{98, 86},
                    new List<int>
                    {
                        98 * MeterType.Water.Cost,
                        86 * MeterType.Water.Cost
                    }
                }
            };

            return list.Skip(position).Take(1);
        }

        public static IEnumerable<object[]> BadInputs()
        {
            var list = new List<object[]>
            {
                new object[] {
                    typeof(ArgumentNullException),
                    null,
                    new List<int>{97, 50}
                },

                new object[]
                {
                    typeof(ArgumentNullException),
                    Guid.NewGuid().ToString(),
                    null
                },

                new object[]
                {
                    typeof(ArgumentException),
                    Guid.NewGuid().ToString(),
                    new List<int>{ - 98, 86}
                }
            };

            return list;
        }
    }
}
