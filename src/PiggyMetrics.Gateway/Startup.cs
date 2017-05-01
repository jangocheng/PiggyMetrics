
using System;
using Google.Protobuf;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PiggyMetrics.Common;

namespace PiggyMetrics.Gateway
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
            services.Configure<RouterOption>(Configuration.GetSection("RouterOption"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //app.UseMvc();
            app.Run(async (context)=>{
               string path = context.Request.Path;
               string method = context.Request.Method;
               //假设匹配到了
               int serviceId = 200;
               int msgId = 1;

               IMessage msg = ParseFromRequest(serviceId,msgId, context.Request);
               byte[] data = msg.ToByteArray();


               var req = FindAccountReq.Parser.ParseJson("");
               await context.Response.WriteAsync("Hello World:"+context.Request.Path);
            });
        }

        private IMessage ParseFromRequest(int serviceId, int msgId, HttpRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
