// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: services/statistic.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace PiggyMetrics.Common {

  /// <summary>Holder for reflection information generated from services/statistic.proto</summary>
  public static partial class StatisticReflection {

    #region Descriptor
    /// <summary>File descriptor for services/statistic.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static StatisticReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChhzZXJ2aWNlcy9zdGF0aXN0aWMucHJvdG8SBmRvdGJwZRoTZG90YnBlX29w",
            "dGlvbi5wcm90bxoNbWVzc2FnZS5wcm90byJRCgdTdGF0UnNwEg4KBnN0YXR1",
            "cxgBIAEoBRIPCgdtZXNzYWdlGAIgASgJEiUKCmRhdGFfcG9pbnQYAyADKAsy",
            "ES5kb3RicGUuRGF0YVBvaW50IisKCkl0ZW1NZXRyaWMSDQoFdGl0bGUYASAB",
            "KAkSDgoGYW1vdW50GAIgASgBIpoBCglEYXRhUG9pbnQSDwoHYWNjb3VudBgB",
            "IAEoCRIMCgRkYXRlGAIgASgJEiMKB2luY29tZXMYAyADKAsyEi5kb3RicGUu",
            "SXRlbU1ldHJpYxIkCghleHBlbnNlcxgEIAMoCzISLmRvdGJwZS5JdGVtTWV0",
            "cmljEiMKBHN0YXQYBSADKAsyFS5kb3RicGUuRGF0YVBvaW50U3RhdCJICg1E",
            "YXRhUG9pbnRTdGF0EicKC3N0YXRfbWV0cmljGAEgASgOMhIuZG90YnBlLlN0",
            "YXRNZXRyaWMSDgoGYW1vdW50GAIgASgBKj0KClN0YXRNZXRyaWMSCgoGU01O",
            "T05FEAASCgoGSU5DT01FEAESCwoHRVhQRU5TRRACEgoKBlNBVklORxADMpgB",
            "ChBTdGF0aXN0aWNTZXJ2aWNlEj0KEFVwZGF0ZVN0YXRpc3RpY3MSEi5kb3Ri",
            "cGUuQWNjb3VudFJlcRoPLmRvdGJwZS5Wb2lkUnNwIgTQ8xgBEj4KDUZpbmRC",
            "eUFjY291bnQSFi5kb3RicGUuRmluZEFjY291bnRSZXEaDy5kb3RicGUuU3Rh",
            "dFJzcCIE0PMYAhoFyPMY6wdCHEgBqgITUGlnZ3lNZXRyaWNzLkNvbW1vbvDz",
            "GAFQAFABYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::DotBPE.ProtoBuf.DotbpeOptionReflection.Descriptor, global::PiggyMetrics.Common.MessageReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::PiggyMetrics.Common.StatMetric), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::PiggyMetrics.Common.StatRsp), global::PiggyMetrics.Common.StatRsp.Parser, new[]{ "Status", "Message", "DataPoint" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PiggyMetrics.Common.ItemMetric), global::PiggyMetrics.Common.ItemMetric.Parser, new[]{ "Title", "Amount" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PiggyMetrics.Common.DataPoint), global::PiggyMetrics.Common.DataPoint.Parser, new[]{ "Account", "Date", "Incomes", "Expenses", "Stat" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PiggyMetrics.Common.DataPointStat), global::PiggyMetrics.Common.DataPointStat.Parser, new[]{ "StatMetric", "Amount" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum StatMetric {
    [pbr::OriginalName("SMNONE")] Smnone = 0,
    [pbr::OriginalName("INCOME")] Income = 1,
    [pbr::OriginalName("EXPENSE")] Expense = 2,
    [pbr::OriginalName("SAVING")] Saving = 3,
  }

  #endregion

  #region Messages
  public sealed partial class StatRsp : pb::IMessage<StatRsp> {
    private static readonly pb::MessageParser<StatRsp> _parser = new pb::MessageParser<StatRsp>(() => new StatRsp());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<StatRsp> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PiggyMetrics.Common.StatisticReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StatRsp() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StatRsp(StatRsp other) : this() {
      status_ = other.status_;
      message_ = other.message_;
      dataPoint_ = other.dataPoint_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StatRsp Clone() {
      return new StatRsp(this);
    }

    /// <summary>Field number for the "status" field.</summary>
    public const int StatusFieldNumber = 1;
    private int status_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Status {
      get { return status_; }
      set {
        status_ = value;
      }
    }

    /// <summary>Field number for the "message" field.</summary>
    public const int MessageFieldNumber = 2;
    private string message_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Message {
      get { return message_; }
      set {
        message_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "data_point" field.</summary>
    public const int DataPointFieldNumber = 3;
    private static readonly pb::FieldCodec<global::PiggyMetrics.Common.DataPoint> _repeated_dataPoint_codec
        = pb::FieldCodec.ForMessage(26, global::PiggyMetrics.Common.DataPoint.Parser);
    private readonly pbc::RepeatedField<global::PiggyMetrics.Common.DataPoint> dataPoint_ = new pbc::RepeatedField<global::PiggyMetrics.Common.DataPoint>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::PiggyMetrics.Common.DataPoint> DataPoint {
      get { return dataPoint_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as StatRsp);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(StatRsp other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Status != other.Status) return false;
      if (Message != other.Message) return false;
      if(!dataPoint_.Equals(other.dataPoint_)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Status != 0) hash ^= Status.GetHashCode();
      if (Message.Length != 0) hash ^= Message.GetHashCode();
      hash ^= dataPoint_.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Status != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Status);
      }
      if (Message.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Message);
      }
      dataPoint_.WriteTo(output, _repeated_dataPoint_codec);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Status != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Status);
      }
      if (Message.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Message);
      }
      size += dataPoint_.CalculateSize(_repeated_dataPoint_codec);
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(StatRsp other) {
      if (other == null) {
        return;
      }
      if (other.Status != 0) {
        Status = other.Status;
      }
      if (other.Message.Length != 0) {
        Message = other.Message;
      }
      dataPoint_.Add(other.dataPoint_);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            Status = input.ReadInt32();
            break;
          }
          case 18: {
            Message = input.ReadString();
            break;
          }
          case 26: {
            dataPoint_.AddEntriesFrom(input, _repeated_dataPoint_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class ItemMetric : pb::IMessage<ItemMetric> {
    private static readonly pb::MessageParser<ItemMetric> _parser = new pb::MessageParser<ItemMetric>(() => new ItemMetric());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ItemMetric> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PiggyMetrics.Common.StatisticReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ItemMetric() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ItemMetric(ItemMetric other) : this() {
      title_ = other.title_;
      amount_ = other.amount_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ItemMetric Clone() {
      return new ItemMetric(this);
    }

    /// <summary>Field number for the "title" field.</summary>
    public const int TitleFieldNumber = 1;
    private string title_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Title {
      get { return title_; }
      set {
        title_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "amount" field.</summary>
    public const int AmountFieldNumber = 2;
    private double amount_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Amount {
      get { return amount_; }
      set {
        amount_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ItemMetric);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ItemMetric other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Title != other.Title) return false;
      if (Amount != other.Amount) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Title.Length != 0) hash ^= Title.GetHashCode();
      if (Amount != 0D) hash ^= Amount.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Title.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Title);
      }
      if (Amount != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Amount);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Title.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Title);
      }
      if (Amount != 0D) {
        size += 1 + 8;
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ItemMetric other) {
      if (other == null) {
        return;
      }
      if (other.Title.Length != 0) {
        Title = other.Title;
      }
      if (other.Amount != 0D) {
        Amount = other.Amount;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Title = input.ReadString();
            break;
          }
          case 17: {
            Amount = input.ReadDouble();
            break;
          }
        }
      }
    }

  }

  public sealed partial class DataPoint : pb::IMessage<DataPoint> {
    private static readonly pb::MessageParser<DataPoint> _parser = new pb::MessageParser<DataPoint>(() => new DataPoint());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<DataPoint> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PiggyMetrics.Common.StatisticReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DataPoint() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DataPoint(DataPoint other) : this() {
      account_ = other.account_;
      date_ = other.date_;
      incomes_ = other.incomes_.Clone();
      expenses_ = other.expenses_.Clone();
      stat_ = other.stat_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DataPoint Clone() {
      return new DataPoint(this);
    }

    /// <summary>Field number for the "account" field.</summary>
    public const int AccountFieldNumber = 1;
    private string account_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Account {
      get { return account_; }
      set {
        account_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "date" field.</summary>
    public const int DateFieldNumber = 2;
    private string date_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Date {
      get { return date_; }
      set {
        date_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "incomes" field.</summary>
    public const int IncomesFieldNumber = 3;
    private static readonly pb::FieldCodec<global::PiggyMetrics.Common.ItemMetric> _repeated_incomes_codec
        = pb::FieldCodec.ForMessage(26, global::PiggyMetrics.Common.ItemMetric.Parser);
    private readonly pbc::RepeatedField<global::PiggyMetrics.Common.ItemMetric> incomes_ = new pbc::RepeatedField<global::PiggyMetrics.Common.ItemMetric>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::PiggyMetrics.Common.ItemMetric> Incomes {
      get { return incomes_; }
    }

    /// <summary>Field number for the "expenses" field.</summary>
    public const int ExpensesFieldNumber = 4;
    private static readonly pb::FieldCodec<global::PiggyMetrics.Common.ItemMetric> _repeated_expenses_codec
        = pb::FieldCodec.ForMessage(34, global::PiggyMetrics.Common.ItemMetric.Parser);
    private readonly pbc::RepeatedField<global::PiggyMetrics.Common.ItemMetric> expenses_ = new pbc::RepeatedField<global::PiggyMetrics.Common.ItemMetric>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::PiggyMetrics.Common.ItemMetric> Expenses {
      get { return expenses_; }
    }

    /// <summary>Field number for the "stat" field.</summary>
    public const int StatFieldNumber = 5;
    private static readonly pb::FieldCodec<global::PiggyMetrics.Common.DataPointStat> _repeated_stat_codec
        = pb::FieldCodec.ForMessage(42, global::PiggyMetrics.Common.DataPointStat.Parser);
    private readonly pbc::RepeatedField<global::PiggyMetrics.Common.DataPointStat> stat_ = new pbc::RepeatedField<global::PiggyMetrics.Common.DataPointStat>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::PiggyMetrics.Common.DataPointStat> Stat {
      get { return stat_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as DataPoint);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(DataPoint other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Account != other.Account) return false;
      if (Date != other.Date) return false;
      if(!incomes_.Equals(other.incomes_)) return false;
      if(!expenses_.Equals(other.expenses_)) return false;
      if(!stat_.Equals(other.stat_)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Account.Length != 0) hash ^= Account.GetHashCode();
      if (Date.Length != 0) hash ^= Date.GetHashCode();
      hash ^= incomes_.GetHashCode();
      hash ^= expenses_.GetHashCode();
      hash ^= stat_.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Account.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Account);
      }
      if (Date.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Date);
      }
      incomes_.WriteTo(output, _repeated_incomes_codec);
      expenses_.WriteTo(output, _repeated_expenses_codec);
      stat_.WriteTo(output, _repeated_stat_codec);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Account.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Account);
      }
      if (Date.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Date);
      }
      size += incomes_.CalculateSize(_repeated_incomes_codec);
      size += expenses_.CalculateSize(_repeated_expenses_codec);
      size += stat_.CalculateSize(_repeated_stat_codec);
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(DataPoint other) {
      if (other == null) {
        return;
      }
      if (other.Account.Length != 0) {
        Account = other.Account;
      }
      if (other.Date.Length != 0) {
        Date = other.Date;
      }
      incomes_.Add(other.incomes_);
      expenses_.Add(other.expenses_);
      stat_.Add(other.stat_);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Account = input.ReadString();
            break;
          }
          case 18: {
            Date = input.ReadString();
            break;
          }
          case 26: {
            incomes_.AddEntriesFrom(input, _repeated_incomes_codec);
            break;
          }
          case 34: {
            expenses_.AddEntriesFrom(input, _repeated_expenses_codec);
            break;
          }
          case 42: {
            stat_.AddEntriesFrom(input, _repeated_stat_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class DataPointStat : pb::IMessage<DataPointStat> {
    private static readonly pb::MessageParser<DataPointStat> _parser = new pb::MessageParser<DataPointStat>(() => new DataPointStat());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<DataPointStat> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PiggyMetrics.Common.StatisticReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DataPointStat() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DataPointStat(DataPointStat other) : this() {
      statMetric_ = other.statMetric_;
      amount_ = other.amount_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DataPointStat Clone() {
      return new DataPointStat(this);
    }

    /// <summary>Field number for the "stat_metric" field.</summary>
    public const int StatMetricFieldNumber = 1;
    private global::PiggyMetrics.Common.StatMetric statMetric_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::PiggyMetrics.Common.StatMetric StatMetric {
      get { return statMetric_; }
      set {
        statMetric_ = value;
      }
    }

    /// <summary>Field number for the "amount" field.</summary>
    public const int AmountFieldNumber = 2;
    private double amount_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Amount {
      get { return amount_; }
      set {
        amount_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as DataPointStat);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(DataPointStat other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (StatMetric != other.StatMetric) return false;
      if (Amount != other.Amount) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (StatMetric != 0) hash ^= StatMetric.GetHashCode();
      if (Amount != 0D) hash ^= Amount.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (StatMetric != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) StatMetric);
      }
      if (Amount != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Amount);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (StatMetric != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) StatMetric);
      }
      if (Amount != 0D) {
        size += 1 + 8;
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(DataPointStat other) {
      if (other == null) {
        return;
      }
      if (other.StatMetric != 0) {
        StatMetric = other.StatMetric;
      }
      if (other.Amount != 0D) {
        Amount = other.Amount;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            statMetric_ = (global::PiggyMetrics.Common.StatMetric) input.ReadEnum();
            break;
          }
          case 17: {
            Amount = input.ReadDouble();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
