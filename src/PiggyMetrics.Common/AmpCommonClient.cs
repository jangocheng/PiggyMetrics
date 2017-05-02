using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotBPE.Protocol.Amp;
using DotBPE.Rpc;
using DotBPE.Rpc.Exceptions;
using Google.Protobuf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PiggyMetrics.Common
{
    public class AmpCommonClient : AmpInvokeClient
    {
        public AmpCommonClient(IRpcClient<AmpMessage> client) : base(client)
        {

        }

        public async Task<CallResult> SendAsync(ushort serviceId,ushort messageId ,Dictionary<string,string> routerData,int timeOut = 3000)
        {
            CallResult result = new CallResult();
            AmpMessage request = AmpMessage.CreateRequestMessage(serviceId,messageId);
            IMessage reqTemp= ProtobufObjectFactory.GetRequestTemplate(serviceId,messageId);
            if(reqTemp ==null){
                result.Status = -1;
                result.Message = "请求消息未定义";
                return result;
            }


            try
            {
                var descriptor = reqTemp.Descriptor;
                foreach (var field in descriptor.Fields.InDeclarationOrder())
                {
                    if( routerData.ContainsKey(field.Name) )
                    {
                            field.Accessor.SetValue(reqTemp,routerData[field.Name]);
                    }
                    else if(routerData.ContainsKey(field.JsonName))
                    {
                            field.Accessor.SetValue(reqTemp,routerData[field.JsonName]);
                    }

                }
                request.Data = reqTemp.ToByteArray();

            }
            catch(Exception ex){
                result.Status = -1;
                result.Message = "编码错误:"+ex.Message+"\n"+ex.StackTrace;
                return result;
            }

            try{
                var rsp = await base.CallInvoker.AsyncCall(request,timeOut);
                if(rsp !=null && rsp.Data !=null){
                   var rspTemp = ProtobufObjectFactory.GetResponseTemplate(serviceId,messageId);
                    if(rspTemp ==null){
                        result.Status = -1;
                        result.Message = "响应消息未定义";
                        return result;
                    }
                   rspTemp.MergeFrom(rsp.Data);
                   result.Content = JsonFormatter.Default.Format(rspTemp);
                }
            }
            catch(RpcCommunicationException rpcEx){
                result.Status = -2;
                result.Message = "调用超时"+rpcEx.Message+"\n"+rpcEx.StackTrace;
            }
            catch(Exception ex){
                result.Status = -1;
                result.Message = "调用出现异常:"+ex.Message;
            }
            return result;

        }
    }


}