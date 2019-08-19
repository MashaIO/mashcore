namespace Masha.Foundation.Tests
{
    using System;
    using Xunit;
    using FakeItEasy;
    using Masha.Foundation;
    using static Masha.Foundation.Core;
    using static Masha.Foundation.Tests.General;

    public class WriterMonadTests
    {
        [Fact]
        public void Return_Writert__When_Elevate_AType()
        {
            var expectedLog = "Employee instantiated";
            var employee = new Employee("Abdul");
            var wemp = Writer(employee, expectedLog);
            Assert.Equal(employee.Name, wemp.AsOption.Value.Name);
            Assert.Equal(expectedLog, wemp.Log);
        }
    }
}
