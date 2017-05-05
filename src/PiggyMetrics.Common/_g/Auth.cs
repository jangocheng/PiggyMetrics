// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: services/auth.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace PiggyMetrics.Common {

  /// <summary>Holder for reflection information generated from services/auth.proto</summary>
  public static partial class AuthReflection {

    #region Descriptor
    /// <summary>File descriptor for services/auth.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static AuthReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChNzZXJ2aWNlcy9hdXRoLnByb3RvEgZkb3RicGUaE2RvdGJwZV9vcHRpb24u",
            "cHJvdG8aDW1lc3NhZ2UucHJvdG8iOwoHQXV0aFJzcBIOCgZzdGF0dXMYASAB",
            "KAUSDwoHbWVzc2FnZRgCIAEoCRIPCgdhY2NvdW50GAMgASgJMnAKC0F1dGhT",
            "ZXJ2aWNlEi0KBkNyZWF0ZRIMLmRvdGJwZS5Vc2VyGg8uZG90YnBlLlZvaWRS",
            "c3AiBNDzGAESKwoEQXV0aBIMLmRvdGJwZS5Vc2VyGg8uZG90YnBlLkF1dGhS",
            "c3AiBNDzGAIaBcjzGOoHQhxIAaoCE1BpZ2d5TWV0cmljcy5Db21tb27w8xgB",
            "UABQAWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::DotBPE.ProtoBuf.DotbpeOptionReflection.Descriptor, global::PiggyMetrics.Common.MessageReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::PiggyMetrics.Common.AuthRsp), global::PiggyMetrics.Common.AuthRsp.Parser, new[]{ "Status", "Message", "Account" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class AuthRsp : pb::IMessage<AuthRsp> {
    private static readonly pb::MessageParser<AuthRsp> _parser = new pb::MessageParser<AuthRsp>(() => new AuthRsp());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AuthRsp> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PiggyMetrics.Common.AuthReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthRsp() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthRsp(AuthRsp other) : this() {
      status_ = other.status_;
      message_ = other.message_;
      account_ = other.account_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthRsp Clone() {
      return new AuthRsp(this);
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

    /// <summary>Field number for the "account" field.</summary>
    public const int AccountFieldNumber = 3;
    private string account_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Account {
      get { return account_; }
      set {
        account_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AuthRsp);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AuthRsp other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Status != other.Status) return false;
      if (Message != other.Message) return false;
      if (Account != other.Account) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Status != 0) hash ^= Status.GetHashCode();
      if (Message.Length != 0) hash ^= Message.GetHashCode();
      if (Account.Length != 0) hash ^= Account.GetHashCode();
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
      if (Account.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Account);
      }
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
      if (Account.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Account);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AuthRsp other) {
      if (other == null) {
        return;
      }
      if (other.Status != 0) {
        Status = other.Status;
      }
      if (other.Message.Length != 0) {
        Message = other.Message;
      }
      if (other.Account.Length != 0) {
        Account = other.Account;
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
            Status = input.ReadInt32();
            break;
          }
          case 18: {
            Message = input.ReadString();
            break;
          }
          case 26: {
            Account = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
