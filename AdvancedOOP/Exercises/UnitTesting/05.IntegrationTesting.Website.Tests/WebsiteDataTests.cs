namespace _05.IntegrationTesting.Website.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WebsiteDataTests
    {
        private WebsiteData site;

        [TestInitialize]
        public void InitializeData()
        {
            this.site = new WebsiteData();
        }

        [TestMethod]
        public void Website_AddCategory_ShouldAddCategoryCorrectly()
        {
            this.site.AddCategory(new Category("Something"));

            Assert.IsTrue(this.site.Database.ContainsKey("Something"));
        }
        [TestMethod]
        public void Website_RemoveCategory_ShouldRemoveCategory()
        {
            this.site.AddCategory(new Category("Category_1"));
            this.site.RemoveCategory("Category_1");

            Assert.IsFalse(this.site.Database.ContainsKey("Category_1"));
        }

        [TestMethod]
        public void Webisite_RemoveCategory_ShouldTrasferUsersToChildCategory()
        {
            var parent = new Category("parent");
            var child = new Category("child");
            var parentUser = new User("parentUser");

            parent.AssignChildCategory(child);
            parent.AssignUser(parentUser);

            // Note that we do not add the child to the database here.
            this.site.AddCategory(parent);
            this.site.RemoveCategory("parent");

            /* Note that we did NOT add the child direcly into the database.
               This is automated and we can safely check if 'parentUser' was added to the child,
               before the parent was removed from the database,
               which is what the problem description says should happen.
               */
            var category = this.site.GetCategoryByName("child");

            Assert.IsTrue(category.Users.ContainsKey("parentUser"));
        }
    }
}