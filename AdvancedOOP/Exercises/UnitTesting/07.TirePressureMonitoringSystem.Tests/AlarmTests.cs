namespace _07.TirePressureMonitoringSystem.Tests
{
    using Moq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TirePressureMonitoringSystem;

    [TestClass]
    public class AlarmTests
    {
        [TestMethod]
        public void Alarm_Check_PressureBelow17_ShouldSetAlarmOn()
        {
            double lowPressure = 15;

            var sensorMock = new Mock<ISensor>();
            sensorMock
                .Setup(s => s.PopNextPressurePsiValue())
                .Returns(lowPressure);

            var alarm = new Alarm();

            alarm.Check(sensorMock.Object);

            Assert.IsTrue(alarm.AlarmOn);
        }

        [TestMethod]
        public void Alarm_Check_PressureAtLowBorder_ShouldNotSetAlarmOn()
        {
            double LowPressureThreshold = 17;

            var sensorMock = new Mock<ISensor>();
            sensorMock
                .Setup(s => s.PopNextPressurePsiValue())
                .Returns(LowPressureThreshold);


            var alarm = new Alarm();

            alarm.Check(sensorMock.Object);
            Assert.IsFalse(alarm.AlarmOn);
        }

        [TestMethod]
        public void Alarm_Check_MidPressure_ShouldNotSetAlarmOn()
        {
            double mid = 17;

            var sensorMock = new Mock<ISensor>();
            sensorMock
                .Setup(s => s.PopNextPressurePsiValue())
                .Returns(mid);


            var alarm = new Alarm();
            alarm.Check(sensorMock.Object);

            Assert.IsFalse(alarm.AlarmOn);
        }

        [TestMethod]
        public void Alarm_Check_PresssureAtUpperBorder_ShouldNotSetAlarmOn()
        {
            double highPressureTreshhold = 21;

            var sensorMock = new Mock<ISensor>();
            sensorMock
                .Setup(s => s.PopNextPressurePsiValue())
                .Returns(highPressureTreshhold);


            var alarm = new Alarm();
            alarm.Check(sensorMock.Object);

            Assert.IsFalse(alarm.AlarmOn);
        }

        [TestMethod]
        public void Alarm_Check_PressureOveverload_ShouldNotSetAlarmOn()
        {
            double pressureOverload = 21;

            var sensorMock = new Mock<ISensor>();
            sensorMock
                .Setup(s => s.PopNextPressurePsiValue())
                .Returns(pressureOverload);


            var alarm = new Alarm();
            alarm.Check(sensorMock.Object);

            Assert.IsFalse(alarm.AlarmOn);
        }
    }
}
