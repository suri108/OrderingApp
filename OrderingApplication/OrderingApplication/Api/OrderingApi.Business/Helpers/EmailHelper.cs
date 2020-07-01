using System.Threading.Tasks;

namespace OrderingApi.Business.Helpers
{
    public static class EmailHelper
    {
        public static async Task<string> Process()
        {
            return "Email has been sent to owner about activation/upgrade.";
        }
    }
}