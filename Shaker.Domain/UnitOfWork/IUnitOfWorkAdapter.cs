namespace Shaker.Domain.UnitOfWork;

public interface IUnitOfWorkAdapter : IDisposable
{
    IUnitOfWorkRepository Repositories { get; }
    void SaveChanges();
}
