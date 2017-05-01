using System;
using DotBPE.Protocol.Amp;
using DotBPE.Rpc;
using Microsoft.Extensions.DependencyInjection;
using PiggyMetrics.Common;

namespace PiggyMetrics.AuthService
{
    public class DotBpeStartup : StartupBase
    {
        protected override void AddServiceActors(ActorsCollection<AmpMessage> services)
        {
            throw new NotImplementedException();
        }

        protected override void AddBizServices(IServiceCollection services)
        {
            throw new NotImplementedException();
        }
    }
}
