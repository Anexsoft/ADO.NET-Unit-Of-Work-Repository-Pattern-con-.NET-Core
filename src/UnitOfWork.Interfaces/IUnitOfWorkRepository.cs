using Repository.Interfaces;

namespace UnitOfWork.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        IProductRepository ProductRepository { get; }
        IClientRepository ClientRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IInvoiceDetailRepository InvoiceDetailRepository { get; }
    }
}
