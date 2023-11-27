namespace Shaker.Domain.UnitOfWork;

public interface IUnitOfWork
{
    IUnitOfWorkAdapter Create();
}
