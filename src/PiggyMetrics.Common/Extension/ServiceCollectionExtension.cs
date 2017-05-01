using System;
using System.Collections.Generic;
using System.Text;
using DotBPE.Protocol.Amp;
using DotBPE.Rpc;
using DotBPE.Rpc.DefaultImpls;
using DotBPE.Rpc.Netty;
using Microsoft.Extensions.DependencyInjection;

namespace PiggyMetrics.Common.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAmpConsulClient(this IServiceCollection services)
        {
            services.Remove(ServiceDescriptor.Singleton(typeof(IRpcClient<AmpMessage>)));

            return services.AddSingleton<IRpcClient<AmpMessage>, BridgeRpcClient<AmpMessage>>() //在服务端使用客户端链接 需要使用桥接式的实现
                .AddSingleton<IBridgeRouter<AmpMessage>, AmpBridgeConsulRouter>() //桥接路由器
                .AddSingleton<ITransportFactory<AmpMessage>, DefaultTransportFactory<AmpMessage>>()
                .AddSingleton<IClientBootstrap<AmpMessage>, NettyClientBootstrap<AmpMessage>>();
        }
    }
}
