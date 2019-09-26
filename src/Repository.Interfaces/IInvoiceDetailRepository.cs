using Models;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IInvoiceDetailRepository
    {
        void Create(IEnumerable<InvoiceDetail> model, int invoiceId);
        IEnumerable<InvoiceDetail> GetAllByInvoiceId(int invoiceId);
        void RemoveByInvoiceId(int invoiceId);
    }
}
