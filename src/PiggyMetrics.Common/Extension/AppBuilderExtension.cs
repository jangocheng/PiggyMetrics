using System;
using System.Collections.Generic;
using System.Text;
using DotBPE.Protocol.Amp;
using DotBPE.Rpc;
using Microsoft.Extensions.DependencyInjection;
using PiggyMetrics.Common.Consul.Service;

namespace PiggyMetrics.Common.Extension
{
    public static class AppBuilderExtension
    {
        public static IAppBuilder UseConsulRegistration(this IAppBuilder builder,string serviceCategory,string localAddress,int port)
        {
            // 服务注册
            var localImpls = builder.ServiceProvider.GetServices<IServiceActor<AmpMessage>>();
            var serviceRegistor = builder.ServiceProvider.GetRequiredService<IServiceRegistration>();
            foreach (var actors in localImpls)
            {
                ServiceMeta meta = new ServiceMeta
                {
                    Id = serviceCategory + "$" + actors.Id.Split('$')[0],
                    ServiceName = actors.GetType().FullName,
                    Address = localAddress,
                    Port = port
                };
                serviceRegistor.Register(meta);
            }
            return builder;
        }
    }
}
