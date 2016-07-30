namespace _05.IntegrationTesting
{
    using System.Collections.Generic;

    public interface ICategory : IModel
    {
        IReadOnlyDictionary<string, IUser> Users { get; }

        ICategory Child { get; }

        bool HasUsers();

        void AssignMultipleUsers(IDictionary<string, IUser> usersToAdd);
        void TransferUsersToChild();
    }
}