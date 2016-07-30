namespace _05.IntegrationTesting
{
    using System;
    using System.Collections.Generic;

    public class WebsiteData
    {
        private IDictionary<string, ICategory> database;

        public WebsiteData()
        {
            this.database = new Dictionary<string, ICategory>();
        }

        public IReadOnlyDictionary<string, ICategory> Database => this.database as IReadOnlyDictionary<string, ICategory>;

        public void AddCategory(ICategory category)
        {
            this.database.Add(category.Name, category);
        }

        public void RemoveCategory(string categoryName)
        {
            var categoryToRemove = this.database[categoryName];
            if (categoryToRemove.HasUsers())
            {
                categoryToRemove.TransferUsersToChild();
            }

            if (categoryToRemove.Child != null)
            {
                this.AddCategory(categoryToRemove.Child);
            }

            this.database.Remove(categoryName);
        }

        public ICategory GetCategoryByName(string categoryName)
        {
            if (this.database.ContainsKey(categoryName))
            {
                return this.database[categoryName];
            }

            throw new InvalidOperationException($"Category with name <{categoryName}> does not exist.");
        }
    }
}