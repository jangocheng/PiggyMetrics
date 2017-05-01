using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;

namespace PiggyMetrics.Common.Consul.Service
{
    public class ConsulServiceDiscovery: IServiceDiscovery
    {
        private readonly ConsulClient _client;

        private readonly string _serviceCategory ;
        private ulong _lastIndex;
        private readonly HashSet<string> _requireServices;
        public ConsulServiceDiscovery(string serviceCategory,string requireServices,Action<ConsulClientConfiguration> configOverride)
        {
            this._serviceCategory = serviceCategory;
            this._client = new ConsulClient(configOverride);

             _requireServices = new HashSet<string>();
            InitRequireServices(requireServices);
        }

        private void InitRequireServices(string requireServices)
        {

            string[] services =requireServices.Split(',');

            foreach(string serviceId in services){
                _requireServices.Add(serviceId);
            }

        }

        public async Task<List<ServiceMeta>> FindAll()
        {
            List<ServiceMeta> list = new List<ServiceMeta>();
            var reslut = await this._client.Agent.Services();

            if (reslut.StatusCode == System.Net.HttpStatusCode.OK )
            {
                if (reslut.Response != null && reslut.Response.Count > 0)
                {
                    if (reslut.LastIndex > this._lastIndex)
                    {
                        _lastIndex = reslut.LastIndex;
                        foreach (var kv in reslut.Response)
                        {
                            if (!kv.Key.StartsWith(_serviceCategory))
                            {
                                continue;
                            }

                            if(!this._requireServices.Contains(kv.Value.ID)){
                                continue;
                            }
                            ServiceMeta meta = new ServiceMeta
                            {
                                Id = kv.Value.ID,
                                ServiceName = kv.Value.Service,
                                Address= kv.Value.Address,
                                Port = kv.Value.Port
                            };
                            list.Add(meta);
                        }
                    }
                }
            }
            else if
                (reslut.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                //找不到的话 就不做处理了
            }
            else
            {
                throw new Exception($"call find services error,return code {reslut.StatusCode}");
            }
            return list;
        }
    }
}
