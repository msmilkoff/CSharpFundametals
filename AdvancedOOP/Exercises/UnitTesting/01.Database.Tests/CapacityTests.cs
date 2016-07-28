namespace _01.Database.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _01.Database;

    [TestClass]
    public class CapacityTests
    {
        private const int ExpectedCapacity = 16;

        [TestMethod]
        public void DatabaseConstructor_NoParameters_ShoudInitializeCapacityTo16()
        {
            
            var data = new Database();

            Assert.AreEqual(ExpectedCapacity, data.Length);
        }

        [TestMethod]
        public void Database_PassLessThan16Params_ShoudInitializeCapacityTo16()
        {
            var data = new Database(1, 2, 3);

            Assert.AreEqual(ExpectedCapacity, data.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Database_PassMoreThan16Params_ShoudThrow()
        {
            var items = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            var data = new Database(items);
        }
    }
}