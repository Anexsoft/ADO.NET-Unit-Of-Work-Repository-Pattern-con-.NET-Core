using Models;
using Repository.Interfaces.Actions;

namespace Repository.Interfaces
{
    public interface IProductRepository : IReadRepository<Product, int>
    {

    }
}
