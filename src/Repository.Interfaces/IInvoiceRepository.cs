using Models;
using Repository.Interfaces.Actions;

namespace Repository.Interfaces
{
    public interface IInvoiceRepository : IReadRepository<Invoice, int>, ICreateRepository<Invoice>, IUpdateRepository<Invoice>, IRemoveRepository<int>
    {

    }
}
