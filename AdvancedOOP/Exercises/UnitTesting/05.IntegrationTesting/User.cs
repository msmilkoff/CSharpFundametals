namespace _05.IntegrationTesting
{
    using System.Collections.Generic;

    public class User : IUser
    {
        private IDictionary<string, ICategory> categories;

        public User(string name)
        {
            this.Name = name;
            this.categories = new Dictionary<string, ICategory>();
        }

        public string Name { get; private set; }

        public IReadOnlyDictionary<string, ICategory> Categories => this.categories as IReadOnlyDictionary<string, ICategory>;
    }
}