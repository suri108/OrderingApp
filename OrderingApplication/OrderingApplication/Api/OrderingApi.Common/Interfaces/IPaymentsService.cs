using System.Threading.Tasks;

namespace OrderingApi.Common.Interfaces
{
    public interface IPaymentsService
    {
        Task<string> ProcessPayment(string selection);
    }
}