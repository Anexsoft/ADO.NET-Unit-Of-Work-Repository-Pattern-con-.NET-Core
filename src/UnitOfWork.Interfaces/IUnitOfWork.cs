namespace UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IUnitOfWorkAdapter Create();
    }
}
