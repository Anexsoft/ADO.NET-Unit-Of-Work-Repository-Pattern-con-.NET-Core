using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Models;
using Repository.Interfaces;

namespace Repository.SqlServer
{
    public class InvoiceDetailRepository : Repository, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public void Create(IEnumerable<InvoiceDetail> model, int invoiceId)
        {
            foreach (var detail in model)
            {
                var query = "insert into invoicedetail(invoiceId, productId, quantity, price, iva, subTotal, total) values (@invoiceId, @productId, @quantity, @price, @iva, @subTotal, @total)";
                var command = CreateCommand(query);

                command.Parameters.AddWithValue("@invoiceId", invoiceId);
                command.Parameters.AddWithValue("@productId", detail.ProductId);
                command.Parameters.AddWithValue("@quantity", detail.Quantity);
                command.Parameters.AddWithValue("@price", detail.Price);
                command.Parameters.AddWithValue("@iva", detail.Iva);
                command.Parameters.AddWithValue("@subTotal", detail.SubTotal);
                command.Parameters.AddWithValue("@total", detail.Total);

                command.ExecuteNonQuery();
            }
        }

        public void RemoveByInvoiceId(int invoiceId)
        {
            var command = CreateCommand("DELETE FROM invoicedetail WHERE invoiceId = @invoiceId");
            command.Parameters.AddWithValue("@invoiceId", invoiceId);

            command.ExecuteNonQuery();
        }

        public IEnumerable<InvoiceDetail> GetAllByInvoiceId(int invoiceId)
        {
            var result = new List<InvoiceDetail>();

            var command = CreateCommand("SELECT * FROM invoicedetail WITH(NOLOCK) WHERE invoiceId = @invoiceId");
            command.Parameters.AddWithValue("@invoiceId", invoiceId);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new InvoiceDetail
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        ProductId = Convert.ToInt32(reader["productId"]),
                        Quantity = Convert.ToInt32(reader["quantity"]),
                        Iva = Convert.ToDecimal(reader["iva"]),
                        SubTotal = Convert.ToDecimal(reader["subtotal"]),
                        Total = Convert.ToDecimal(reader["total"])
                    });
                }
            }

            return result;
        }
    }
}
