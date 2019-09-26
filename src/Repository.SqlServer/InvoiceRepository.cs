using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Models;
using Repository.Interfaces;

namespace Repository.SqlServer
{
    public class InvoiceRepository : Repository, IInvoiceRepository
    {
        public InvoiceRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public void Create(Invoice model)
        {
            var query = "insert into invoices(clientId, Iva, SubTotal, Total) output INSERTED.ID values (@clientId, @iva, @subTotal, @total)";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@clientId", model.ClientId);
            command.Parameters.AddWithValue("@iva", model.Iva);
            command.Parameters.AddWithValue("@subTotal", model.SubTotal);
            command.Parameters.AddWithValue("@total", model.Total);

            model.Id = Convert.ToInt32(command.ExecuteScalar());
        }

        public void Remove(int id)
        {
            var command = CreateCommand("DELETE FROM invoices WHERE id = @id");
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
        }

        public Invoice Get(int id)
        {
            var command = CreateCommand("SELECT * FROM invoices WITH(NOLOCK) WHERE id = @id");
            command.Parameters.AddWithValue("@id", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new Invoice
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Iva = Convert.ToDecimal(reader["iva"]),
                    SubTotal = Convert.ToDecimal(reader["subtotal"]),
                    Total = Convert.ToDecimal(reader["total"]),
                    ClientId = Convert.ToInt32(reader["clientId"])
                };
            };
        }

        public IEnumerable<Invoice> GetAll()
        {
            var result = new List<Invoice>();

            var command = CreateCommand("SELECT * FROM invoices WITH(NOLOCK)");

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Invoice
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Iva = Convert.ToDecimal(reader["iva"]),
                        SubTotal = Convert.ToDecimal(reader["subtotal"]),
                        Total = Convert.ToDecimal(reader["total"]),
                        ClientId = Convert.ToInt32(reader["clientId"])
                    });
                }
            }

            return result;
        }

        public void Update(Invoice model)
        {
            var query = "update invoices set clientId = @clientId, iva = @iva, subTotal = @subTotal, total = @total WHERE id = @id";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@clientId", model.ClientId);
            command.Parameters.AddWithValue("@iva", model.Iva);
            command.Parameters.AddWithValue("@subTotal", model.SubTotal);
            command.Parameters.AddWithValue("@total", model.Total);
            command.Parameters.AddWithValue("@id", model.Id);

            command.ExecuteNonQuery();
        }
    }
}
