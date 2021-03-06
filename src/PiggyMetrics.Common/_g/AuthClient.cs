// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: services/auth.proto
#region Designer generated code

using System; 
using System.Threading.Tasks; 
using DotBPE.Rpc; 
using DotBPE.Protocol.Amp; 
using DotBPE.Rpc.Exceptions; 
using Google.Protobuf; 

namespace PiggyMetrics.Common {

//start for class AuthServiceClient
public sealed class AuthServiceClient : AmpInvokeClient 
{
public AuthServiceClient(IRpcClient<AmpMessage> client) : base(client)
{
}
public async Task<VoidRsp> CreateAsync(UserReq request,int timeOut=3000)
{
AmpMessage message = AmpMessage.CreateRequestMessage(1002, 1);
message.Data = request.ToByteArray();
var response = await base.CallInvoker.AsyncCall(message,timeOut);
if (response == null)
{
throw new RpcException("error,response is null !");
}
if (response.Data == null)
{
return new VoidRsp();
}
return VoidRsp.Parser.ParseFrom(response.Data);
}

//同步方法
public VoidRsp Create(UserReq request)
{
AmpMessage message = AmpMessage.CreateRequestMessage(1002, 1);
message.Data = request.ToByteArray();
var response =  base.CallInvoker.BlockingCall(message);
if (response == null)
{
throw new RpcException("error,response is null !");
}
if (response.Data == null)
{
return new VoidRsp();
}
return VoidRsp.Parser.ParseFrom(response.Data);
}
public async Task<AuthRsp> AuthAsync(UserReq request,int timeOut=3000)
{
AmpMessage message = AmpMessage.CreateRequestMessage(1002, 2);
message.Data = request.ToByteArray();
var response = await base.CallInvoker.AsyncCall(message,timeOut);
if (response == null)
{
throw new RpcException("error,response is null !");
}
if (response.Data == null)
{
return new AuthRsp();
}
return AuthRsp.Parser.ParseFrom(response.Data);
}

//同步方法
public AuthRsp Auth(UserReq request)
{
AmpMessage message = AmpMessage.CreateRequestMessage(1002, 2);
message.Data = request.ToByteArray();
var response =  base.CallInvoker.BlockingCall(message);
if (response == null)
{
throw new RpcException("error,response is null !");
}
if (response.Data == null)
{
return new AuthRsp();
}
return AuthRsp.Parser.ParseFrom(response.Data);
}
}
//end for class AuthServiceClient
}
#endregion
