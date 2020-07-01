using System.Threading.Tasks;

namespace OrderingApi.Business.Helpers
{
    public static class CommissionHelper
    {
        public static async Task<string> Process()
        {
            return "Commission payment to the agent is generated.";
        }
    }
}