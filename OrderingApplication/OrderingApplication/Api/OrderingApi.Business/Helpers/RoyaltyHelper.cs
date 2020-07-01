using System.Threading.Tasks;

namespace OrderingApi.Business.Helpers
{
    public static class RoyaltyHelper
    {
        public static async Task<string> Process()
        {
            return "Duplicate packing slip for the royalty department is generated.";
        }
    }
}