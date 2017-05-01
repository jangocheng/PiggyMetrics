using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Google.Protobuf;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PiggyMetrics.Common;

namespace PiggyMetrics.Gateway
{
    public class ForwardService : IForwardService
    {
        private readonly RouterOption _option;
        public ForwardService(IOptions<RouterOption> routerOption){
           Assert.IsNull(routerOption.Value,"RouterOption not found");
           _option = routerOption.Value;
        }
        public Task<string> ForwardAysnc(HttpRequest request)
        {
            string path = request.Path;
            string method = request.Method;

            RouterData rd = FindRouter(path,method,request);
            string json  = ConvertDictToJsonStr(rd.RouterData);

            //JsonFormatter.Default.Format()
            //JsonFormatter.Default.Format()

            throw new NotImplementedException();
        }

        private string ConvertDictToJsonStr(Dictionary<string, string> routerData)
        {

            throw new NotImplementedException();
        }

        private RouterData FindRouter(string path, string method,HttpRequest request)
        {
            for(var i=0; i<_option.Routers.Count ;i++){
                var router = _option.Routers[i];
                if(router.Method.Equals(method,StringComparison.OrdinalIgnoreCase)){
                   var match =  Match(router.Path,path);
                   if(match.Success){
                       RouterData rd = new RouterData();
                       rd.ServiceId = router.ServiceId;
                       rd.MessageId = router.MessageId;
                       rd.RouterData = new Dictionary<string, string>();
                       if( match.Groups !=null && match.Groups.Count>0){
                          AddGroupsToDict(match.Groups,rd.RouterData);
                       }
                       CollectQuery(request.Query,rd.RouterData);
                       CollectForm(request.Form,rd.RouterData);
                       return rd;
                   }
                }
            }

            return null;

        }

        private Dictionary<string, string> CollectForm(IFormCollection form,Dictionary<string, string> dict)
        {
            foreach (string key in form.Keys){
                if(!dict.ContainsKey(key))
                    dict.Add(key,form[key]);
                else
                    dict[key] =form[key];
            }
            return dict;
        }

        private Dictionary<string, string> CollectQuery(IQueryCollection query,Dictionary<string, string> dict)
        {
            foreach (string key in query.Keys){
                if(!dict.ContainsKey(key))
                    dict.Add(key,query[key]);
                else
                    dict[key] = query[key];
            }
            return dict;
        }

        private Dictionary<string, string> AddGroupsToDict(GroupCollection groups,Dictionary<string, string> dict)
        {

            foreach(Group group in groups){
                if(!dict.ContainsKey(group.Name))
                {
                    dict.Add(group.Name,group.Value);
                }
                else
                {
                    dict[group.Name] = group.Value;
                }
            }
            return dict;
        }

        private Match Match(string regex ,string value){
            Regex reg = new Regex(regex, RegexOptions.IgnoreCase);
            return reg.Match(value);
        }
    }


    public class RouterData{
        public int ServiceId{get;set;}
        public int MessageId {get;set;}

        public Dictionary<string,string> RouterData{get;set;}
    }
}
