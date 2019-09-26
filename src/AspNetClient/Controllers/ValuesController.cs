using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services;

namespace AspNetClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public ValuesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(
                _invoiceService.GetAll()
            );
        }
    }
}
