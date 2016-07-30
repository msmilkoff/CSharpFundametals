namespace _05.IntegrationTesting
{
    using System.Collections.Generic;

    public class Category : ICategory
    {
        private KeyValuePair<string, ICategory> child;
        private IDictionary<string, IUser> users;

        public Category(string name)
        {
            this.Name = name;
            this.users = new Dictionary<string, IUser>();
        }

        public string Name { get; private set; }

        public IReadOnlyDictionary<string, IUser> Users => this.users as IReadOnlyDictionary<string, IUser>;

        public ICategory Child => this.child.Value;

        public void AssignChildCategory(ICategory childCategory)
        {
            this.child = new KeyValuePair<string, ICategory>(childCategory.Name, childCategory);
        }

        public void AssignUser(IUser user)
        {
            this.users.Add(user.Name, user);
        }

        public void AssignMultipleUsers(IDictionary<string, IUser> usersToAdd)
        {
            foreach (var user in usersToAdd)
            {
                this.users.Add(user.Value.Name, user.Value);
            }
        }

        public void TransferUsersToChild()
        {
            this.Child.AssignMultipleUsers(this.users);
        }

        public bool HasUsers()
        {
            return this.users.Count > 0;
        }
    }
}