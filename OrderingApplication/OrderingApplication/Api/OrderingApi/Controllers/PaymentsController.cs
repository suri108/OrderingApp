using Microsoft.AspNetCore.Mvc;
using OrderingApi.Common.Interfaces;
using OrderingApi.Common.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace OrderingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsService _paymentsService;

        public PaymentsController(IPaymentsService paymentsService)
        {
            _paymentsService = paymentsService;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment(Payment payment)
        {
            try
            {
                var response = await _paymentsService.ProcessPayment(payment.Selection);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}