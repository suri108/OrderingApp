using System.Threading.Tasks;

namespace OrderingApi.Common.Interfaces
{
    public interface IPaymentsFactory
    {
        IPaymentsProcessor GetProcessor(string selection);
    }
}