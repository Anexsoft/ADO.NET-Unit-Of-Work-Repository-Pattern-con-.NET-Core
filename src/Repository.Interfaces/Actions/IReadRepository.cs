using System.Collections.Generic;

namespace Repository.Interfaces.Actions
{
    public interface IReadRepository<T, Y> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Y id);
    }
}
