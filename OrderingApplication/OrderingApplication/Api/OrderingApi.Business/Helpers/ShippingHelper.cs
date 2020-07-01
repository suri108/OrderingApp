using System.Threading.Tasks;

namespace OrderingApi.Business.Helpers
{
    public static class ShippingHelper
    {
        public static async Task<string> Process()
        {
            return "Packing slip for shipping is generated.";
        }
    }
}