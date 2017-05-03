using System.Threading.Tasks;
using PiggyMetrics.Common;

namespace PiggyMetrics.StatisticService.Impl
{
    public class StatisticServiceImpl : StatisticServiceBase
    {
        public override Task<StatRsp> FindByAccountAsync(FindAccountReq request)
        {
            return Task.FromResult(new StatRsp());
        }

        public override Task<VoidRsp> UpdateStatisticsAsync(Account request)
        {
            return Task.FromResult(new VoidRsp());
        }
    }
}
