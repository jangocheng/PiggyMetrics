// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: services/statistic.proto
#region Designer generated code

using System; 
using System.Threading.Tasks; 
using DotBPE.Rpc; 
using DotBPE.Protocol.Amp; 
using Google.Protobuf; 

namespace PiggyMetrics.Common {

//start for class AbstractStatisticService
public abstract class StatisticServiceBase : ServiceActorBase 
{
public override string Id => "1003$0";
//调用委托
private async Task<AmpMessage> ProcessUpdateStatisticsAsync(AmpMessage req)
{
AccountReq request = null;
if(req.Data == null ){
   request = new AccountReq();
}
else {
request = AccountReq.Parser.ParseFrom(req.Data);
}
var data = await UpdateStatisticsAsync(request);
var response = AmpMessage.CreateResponseMessage(req.ServiceId, req.MessageId);
response.Sequence = req.Sequence;
response.Data = data.ToByteArray();
return response;
}

//抽象方法
public abstract Task<VoidRsp> UpdateStatisticsAsync(AccountReq request);
//调用委托
private async Task<AmpMessage> ProcessFindByAccountAsync(AmpMessage req)
{
FindAccountReq request = null;
if(req.Data == null ){
   request = new FindAccountReq();
}
else {
request = FindAccountReq.Parser.ParseFrom(req.Data);
}
var data = await FindByAccountAsync(request);
var response = AmpMessage.CreateResponseMessage(req.ServiceId, req.MessageId);
response.Sequence = req.Sequence;
response.Data = data.ToByteArray();
return response;
}

//抽象方法
public abstract Task<StatRsp> FindByAccountAsync(FindAccountReq request);
public override Task<AmpMessage> ProcessAsync(AmpMessage req)
{
switch(req.MessageId){
//方法StatisticService.UpdateStatistics
case 1: return this.ProcessUpdateStatisticsAsync(req);
//方法StatisticService.FindByAccount
case 2: return this.ProcessFindByAccountAsync(req);
default: return base.ProcessNotFoundAsync(req);
}
}
}
//end for class AbstractStatisticService
}

#endregion

