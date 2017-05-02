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
            var reslut = await this._client.Health.Service(_serviceCategory);

            if (reslut.StatusCode == System.Net.HttpStatusCode.OK )
            {
                if (reslut.Response != null && reslut.Response.Length > 0)
                {
                    if (reslut.LastIndex > this._lastIndex)
                    {
                        _lastIndex = reslut.LastIndex;
                        foreach (ServiceEntry entry in reslut.Response)
                        {
                            if(!this._requireServices.Contains(entry.Service.ID)){
                                continue;
                            }
                            ServiceMeta meta = new ServiceMeta
                            {
                                Id =  entry.Service.ID,
                                ServiceName =  entry.Service.Service,
                                Address= entry.Service.Address,
                                Port = entry.Service.Port
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
