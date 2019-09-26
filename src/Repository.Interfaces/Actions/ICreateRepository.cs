namespace Repository.Interfaces.Actions
{
    public interface ICreateRepository<T> where T : class
    {
        void Create(T t);
    }
}
