namespace _06.CustomLinkedList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class AddTests
    {
        private DynamicList<int> list;

        [TestInitialize]
        public void InitializeLinkedList()
        {
            this.list = new DynamicList<int>();
        }

        [TestMethod]
        public void Add_ShouldIncrementCount()
        {
            this.list.Add(5);

            int expected = 1;
            int actual = this.list.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_ShouldSaveElement()
        {
            this.list.Add(5);

            Assert.IsTrue(list.Contains(5));
        }

        [TestMethod]
        public void Add_MultipleItems_ShouldAddItemsAtEndOfList()
        {
            int first = 5;
            int second = 10;
            int third = 20;
            this.list.Add(first);
            this.list.Add(second);
            this.list.Add(third);

            Assert.AreEqual(third, this.list[2]);
        }
    }
}