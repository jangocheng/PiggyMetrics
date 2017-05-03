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
private async Task ReceiveUpdateStatisticsAsync(IRpcContext<AmpMessage> context, AmpMessage req)
{
var request = Account.Parser.ParseFrom(req.Data);
var data = await UpdateStatisticsAsync(request);
var response = AmpMessage.CreateResponseMessage(req.ServiceId, req.MessageId);
response.Sequence = req.Sequence;
response.Data = data.ToByteArray();
await context.SendAsync(response);
}

//抽象方法
public abstract Task<VoidRsp> UpdateStatisticsAsync(Account request);
//调用委托
private async Task ReceiveFindByAccountAsync(IRpcContext<AmpMessage> context, AmpMessage req)
{
var request = FindAccountReq.Parser.ParseFrom(req.Data);
var data = await FindByAccountAsync(request);
var response = AmpMessage.CreateResponseMessage(req.ServiceId, req.MessageId);
response.Sequence = req.Sequence;
response.Data = data.ToByteArray();
await context.SendAsync(response);
}

//抽象方法
public abstract Task<StatRsp> FindByAccountAsync(FindAccountReq request);
public override Task ReceiveAsync(IRpcContext<AmpMessage> context, AmpMessage req)
{
switch(req.MessageId){
//方法StatisticService.UpdateStatistics
case 1: return this.ReceiveUpdateStatisticsAsync(context, req);
//方法StatisticService.FindByAccount
case 2: return this.ReceiveFindByAccountAsync(context, req);
default: return base.ReceiveNoFonundAsync(context, req);
}
}
}
//end for class AbstractStatisticService

//start for class AbstractExchangeService
public abstract class ExchangeServiceBase : ServiceActorBase 
{
public override string Id => "1004$0";
//调用委托
private async Task ReceiveGetRatesAsync(IRpcContext<AmpMessage> context, AmpMessage req)
{
var request = VoidReq.Parser.ParseFrom(req.Data);
var data = await GetRatesAsync(request);
var response = AmpMessage.CreateResponseMessage(req.ServiceId, req.MessageId);
response.Sequence = req.Sequence;
response.Data = data.ToByteArray();
await context.SendAsync(response);
}

//抽象方法
public abstract Task<RateRsp> GetRatesAsync(VoidReq request);
//调用委托
private async Task ReceiveConvertAsync(IRpcContext<AmpMessage> context, AmpMessage req)
{
var request = ConvertReq.Parser.ParseFrom(req.Data);
var data = await ConvertAsync(request);
var response = AmpMessage.CreateResponseMessage(req.ServiceId, req.MessageId);
response.Sequence = req.Sequence;
response.Data = data.ToByteArray();
await context.SendAsync(response);
}

//抽象方法
public abstract Task<ConvertRsp> ConvertAsync(ConvertReq request);
public override Task ReceiveAsync(IRpcContext<AmpMessage> context, AmpMessage req)
{
switch(req.MessageId){
//方法ExchangeService.GetRates
case 1: return this.ReceiveGetRatesAsync(context, req);
//方法ExchangeService.Convert
case 2: return this.ReceiveConvertAsync(context, req);
default: return base.ReceiveNoFonundAsync(context, req);
}
}
}
//end for class AbstractExchangeService
}

#endregion

