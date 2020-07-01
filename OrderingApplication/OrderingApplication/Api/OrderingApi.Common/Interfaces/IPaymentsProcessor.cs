using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderingApi.Common.Interfaces
{
    public interface IPaymentsProcessor
    {
        Task<string> Process();
    }
}