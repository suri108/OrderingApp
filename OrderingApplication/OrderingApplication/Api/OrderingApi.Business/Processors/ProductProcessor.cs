using OrderingApi.Business.Helpers;
using OrderingApi.Common.Interfaces;
using System.Threading.Tasks;

namespace OrderingApi.Business.Processors
{
    public class ProductProcessor : IPaymentsProcessor
    {
        public async Task<string> Process()
        {
            return $"{await ShippingHelper.Process()} {await CommissionHelper.Process()}";
        }
    }
}