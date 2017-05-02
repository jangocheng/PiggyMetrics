using DotBPE.Protocol.Amp;
using DotBPE.Rpc;
using Microsoft.Extensions.DependencyInjection;
using PiggyMetrics.StatisticService.Impl;
using PiggyMetrics.StatisticService.Repository;
using PiggyMetrics.Common;

namespace PiggyMetrics.StatisticService
{
    public class DotBpeStartup : StartupBase
    {
        protected override void AddServiceActors(ActorsCollection<AmpMessage> actors)
        {
            actors.Add<Impl.StatisticServiceImpl>();

        }

        protected override void AddBizServices(IServiceCollection services)
        {

        }
    }
}
