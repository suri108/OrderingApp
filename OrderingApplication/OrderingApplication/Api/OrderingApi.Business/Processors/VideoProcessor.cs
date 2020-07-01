using OrderingApi.Business.Helpers;
using OrderingApi.Common.Interfaces;
using System.Threading.Tasks;

namespace OrderingApi.Business.Processors
{
    public class VideoProcessor : IPaymentsProcessor
    {
        public async Task<string> Process()
        {
            return await VideoHelper.Process();
        }
    }
}