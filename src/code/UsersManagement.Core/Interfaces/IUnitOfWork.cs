namespace UsersManagement.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Complete();
    }
}
