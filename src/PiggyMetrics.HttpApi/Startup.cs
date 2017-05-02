
using System;
using Google.Protobuf;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PiggyMetrics.Common;
using PiggyMetrics.Common.Consul.Service;
using PiggyMetrics.Common.Extension;

namespace PiggyMetrics.HttpApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            _localConfiguration = LocalConfig.Load();
            if (string.IsNullOrEmpty(_localConfiguration.ConsulServer))
            {
                throw new Exception("consul.sever 未配置");
            }

            var consulOptions = new ConsulConfigurationOptions
            {
                Key = _localConfiguration.AppName,
                ConsulAddress = new Uri(_localConfiguration.ConsulServer)
            };

            var builder = new ConfigurationBuilder()
                .AddConsul(consulOptions);

            Configuration = builder.Build();
        }
        private readonly LocalConfig _localConfiguration;
        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<RouterOption>(Configuration.GetSection("RouterOption"));
           services.AddSingleton<IForwardService,ForwardService>();
            // 添加服务发现
            services.AddSingleton<IServiceDiscovery>(new ConsulServiceDiscovery("dotbpe",_localConfiguration.RequireService, (config) =>
            {
                config.Address = new Uri(_localConfiguration.ConsulServer);
            }));

            //添加客户端的协议
            services.AddAmpConsulClient();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            IForwardService forwardService  = app.ApplicationServices.GetRequiredService<IForwardService>();
            //app.UseMvc();
            app.Run(async (context)=>{
                Console.WriteLine("receive request:Method={0},Path={1}",context.Request.Method,context.Request.Path);
                var result = await forwardService.ForwardAysnc(context.Request);
                if(result.Status ==0){
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(result.Content);
                }
                else{
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync(result.Message??"服务端异常");
                }

            });
        }

    }
}
