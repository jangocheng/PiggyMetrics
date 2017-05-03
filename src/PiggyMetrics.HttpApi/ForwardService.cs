using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DotBPE.Protocol.Amp;
using DotBPE.Rpc;
using DotBPE.Rpc.Logging;
using Google.Protobuf;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PiggyMetrics.Common;

namespace PiggyMetrics.HttpApi
{
    public class ForwardService : IForwardService
    {
        static ILogger Logger = DotBPE.Rpc.Environment.Logger.ForType<ForwardService>();
        private readonly AmpCommonClient _client;
        private readonly RouterOption _option;

        public ForwardService(IRpcClient<AmpMessage> rpcCleint,IOptionsSnapshot<RouterOption> optionsAccessor){
            Assert.IsNull(optionsAccessor.Value,"RouterOption not found");

            _option = optionsAccessor.Value;

            _client = new AmpCommonClient(rpcCleint);
        }

        public Task<CallResult> ForwardAysnc(HttpRequest request)
        {

            string path = request.Path;
            string method = request.Method;

            RouterData rd = FindRouter(path,method,request);

            if(rd !=null)
            {
                return this._client.SendAsync((ushort)rd.ServiceId,(ushort)rd.MessageId,rd.Data);
            }
            else{
                CallResult result = new CallResult(){
                    Status = -1,
                    Message = "service not found!"
                };

                return Task.FromResult(result);
            }
        }



        private RouterData FindRouter(string path, string method,HttpRequest request)
        {
            Logger.Debug("option time:{0:yyyy-MM-dd HH:mm:ss}",_option.CreateTime);
            for(var i=0; i<_option.Routers.Count ;i++){
                var router = _option.Routers[i];
                if(router.Method.Equals(method,StringComparison.OrdinalIgnoreCase)){
                   var match =  Match(router.Path,path);
                   if(match.Success){
                       RouterData rd = new RouterData();
                       rd.ServiceId = router.ServiceId;
                       rd.MessageId = router.MessageId;
                       rd.Data = new Dictionary<string,string>();
                       if( match.Groups !=null && match.Groups.Count>0){
                          CollectParams(match.Groups,rd.Data);
                       }
                       CollectQuery(request.Query,rd.Data);
                       CollectForm(request.Form,rd.Data);
                       return rd;
                   }
                }
            }

            return null;

        }

        private void CollectForm(IFormCollection form,Dictionary<string,string> routeData)
        {
            foreach (string key in form.Keys){
                if( routeData.ContainsKey(key))
                    routeData[key] = form[key];
                else
                    routeData.Add(key,form[key]);
            }
        }

        private void CollectQuery(IQueryCollection query,Dictionary<string,string> routeData)
        {
            foreach (string key in query.Keys){
                if( routeData.ContainsKey(key))
                    routeData[key] = query[key];
                else
                    routeData.Add(key,query[key]);
            }

        }

        private void CollectParams(GroupCollection groups,Dictionary<string,string> routeData)
        {

            foreach (Group group in groups){
                if( routeData.ContainsKey(group.Name))
                    routeData[group.Name] = group.Value ;
                else
                    routeData.Add(group.Name,group.Value);
            }
        }

        private Match Match(string regex ,string value){
            Regex reg = new Regex(regex, RegexOptions.IgnoreCase);
            return reg.Match(value);
        }
    }


    public class RouterData{
        public int ServiceId{get;set;}
        public int MessageId {get;set;}

        public Dictionary<string,string> Data{get;set;}
    }
}
