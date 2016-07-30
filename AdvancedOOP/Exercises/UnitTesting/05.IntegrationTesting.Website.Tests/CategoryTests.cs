using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace _05.IntegrationTesting.Website.Tests
{
    using System.Linq;
    using IntegrationTesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CategoryTests
    {
        private WebsiteData website;
        [TestInitialize]
        public void InitializeData()
        {
            //this.website = new WebsiteData();
        }

        [TestMethod]
        public void AssignChildCategory_ShouldAssignChildCorreclty()
        {
            var parent = new Category("Parent");
            var child = new Category("Child");

            parent.AssignChildCategory(child);
            string actual = parent.Child.Name;
            string expected = "Child";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AssignUser_ShouldAssignUserCorrectly()
        {
            var category = new Category("Category_1");
            category.AssignUser(new User("User_1"));

            string actual = category.Users.Select(u => u.Value.Name).FirstOrDefault();
            string expected = "User_1";

            Assert.AreEqual(expected, actual);
        }
    }
}
