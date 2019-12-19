using Models;
using Services;
using System;
using System.Collections.Generic;
using UnitOfWork.SqlServer;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var unitOfWork = new UnitOfWorkSqlServer();

            var invoiceService = new InvoiceService(unitOfWork);

            var result = invoiceService.GetAll();

            var invoice = new Invoice
            {
                ClientId = 1,
                Detail = new List<InvoiceDetail>
                {
                    new InvoiceDetail {
                        ProductId = 1,
                        Quantity = 5,
                        Price = 1500
                    },
                    new InvoiceDetail {
                        ProductId = 8,
                        Quantity = 15,
                        Price = 125
                    }
                }
            };

            invoiceService.Create(invoice);
            //invoiceService.Create(invoice);

            //var invoice = new Invoice
            //{
            //    Id = 33,
            //    ClientId = 1,
            //    Detail = new List<InvoiceDetail>
            //    {
            //        new InvoiceDetail {
            //            ProductId = 1,
            //            Quantity = 5,
            //            Price = 1500
            //        },
            //        new InvoiceDetail {
            //            ProductId = 8,
            //            Quantity = 30,
            //            Price = 125
            //        }
            //    }
            //};

            //invoiceService.Update(invoice);

            //invoiceService.Delete(33);

            Console.Read();
        }
    }
}
