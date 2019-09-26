using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Models;
using Repository.Interfaces;

namespace Repository.SqlServer
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public Product Get(int id)
        {
            var command = CreateCommand("SELECT * FROM products WITH(NOLOCK) WHERE id = @productId");

            command.Parameters.AddWithValue("@productId", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new Product
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Price = Convert.ToDecimal(reader["price"]),
                    Name = reader["name"].ToString()
                };
            }
        }

        public IEnumerable<Product> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
