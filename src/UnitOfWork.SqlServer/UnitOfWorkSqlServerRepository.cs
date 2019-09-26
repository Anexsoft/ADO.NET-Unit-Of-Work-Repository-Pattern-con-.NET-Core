using Repository.Interfaces;
using Repository.SqlServer;
using System.Data.SqlClient;
using UnitOfWork.Interfaces;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        public IProductRepository ProductRepository { get; }
        public IClientRepository ClientRepository { get; }
        public IInvoiceRepository InvoiceRepository { get; }
        public IInvoiceDetailRepository InvoiceDetailRepository { get; }

        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            ClientRepository = new ClientRepository(context, transaction);
            ProductRepository = new ProductRepository(context, transaction);
            InvoiceRepository = new InvoiceRepository(context, transaction);
            InvoiceDetailRepository = new InvoiceDetailRepository(context, transaction);
        }
    }
}
