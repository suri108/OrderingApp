using OrderingApi.Common.Interfaces;
using System.Threading.Tasks;

namespace OrderingApi.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IPaymentsFactory _paymentsFactory;

        public PaymentsService(IPaymentsFactory paymentsFactory)
        {
            _paymentsFactory = paymentsFactory;
        }

        public async Task<string> ProcessPayment(string selection)
        {
            return await _paymentsFactory.GetProcessor(selection)?.Process();
        }
    }
}