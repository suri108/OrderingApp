using OrderingApi.Business.Helpers;
using OrderingApi.Common.Interfaces;
using System.Threading.Tasks;

namespace OrderingApi.Business.Processors
{
    public class UpgradeMembershipProcessor : IPaymentsProcessor
    {
        public async Task<string> Process()
        {
            return $"{await UpgradeHelper.Process()} {await EmailHelper.Process()}";
        }
    }
}