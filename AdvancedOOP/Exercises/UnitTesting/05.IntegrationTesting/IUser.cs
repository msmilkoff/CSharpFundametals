namespace _05.IntegrationTesting
{
    using System.Collections.Generic;

    public interface IUser : IModel
    {
        IReadOnlyDictionary<string, ICategory> Categories { get; }
    }
}