using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotBPE.Plugin.Logging;
using DotBPE.Rpc;
using DotBPE.Rpc.Extensions;
using DotBPE.Rpc.Hosting;
using Microsoft.Extensions.Configuration;

namespace PiggyMetrics.Common
{
    public class InteropServer
    {
        public static async Task<IServerHost> StartAsync<TStartup>() where TStartup:IStartup
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            NLoggerWrapper.InitConfig();
            DotBPE.Rpc.Environment.SetLogger(new NLoggerWrapper(typeof(InteropServer)));

            //怎么链接配置中心 获取配置信息呢
            /**
            * 需要 获取那些配置
            1. Account数据库链接信息，加密后
            2. 获取服务启动的参数 端口等
            */
            var builder = new ConfigurationBuilder().AddJsonFile("dotbpe.config.json");
            var configuration = builder.Build();

           

           

            var host = new RpcHostBuilder()
                .UseConfiguration(configuration)
                .UseStartup<TStartup>()
                .Build();

            await host.StartAsync();
            return host;
        }
    }
}
