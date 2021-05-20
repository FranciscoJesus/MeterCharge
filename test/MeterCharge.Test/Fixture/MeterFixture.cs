using MeterCharge.ApplicationCore.Interfaces;
using Moq;

namespace MeterCharge.Test.Fixture
{
    public class MeterFixture
    {
        public readonly IDateService dateServiceIsNightTrue;
        public readonly IDateService dateServiceIsNightFalse;

        public MeterFixture()
        {
            var mockDateServiceIsNightTrue = new Mock<IDateService>();
            var mockDateServiceIsNightFalse = new Mock<IDateService>();

            mockDateServiceIsNightTrue.Setup(s => s.IsNight()).Returns(true);
            mockDateServiceIsNightFalse.Setup(s => s.IsNight()).Returns(false);

            dateServiceIsNightTrue = mockDateServiceIsNightTrue.Object;
            dateServiceIsNightFalse = mockDateServiceIsNightFalse.Object;
        }
    }
}
