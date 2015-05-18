namespace Onixia.Data.Repositories
{
    using Contracts;

    public class GenericRepository<T> : IRepository<T> where T : class
    {
    }
}