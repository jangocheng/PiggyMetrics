using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PiggyMetrics.Gateway
{
    public interface IForwardService
    {
        Task<string> ForwardAysnc(HttpRequest request);
    }
}
