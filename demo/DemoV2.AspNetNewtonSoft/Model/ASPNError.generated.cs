#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using DemoV2.AspNetNewtonSoft.Model.Base;

namespace DemoV2.AspNetNewtonSoft.Model {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class ASPNError : IEquatable<ASPNError> {
        public const string ASPNErrorObjectName = "error";
        /// <summary>
        /// Single string based code describing the error.
        /// </summary>
        [JsonProperty("status", Required = Required.Always)]
        public string Status { get; set; }

        /// <summary>
        /// Human readable error message.
        /// </summary>
        [JsonProperty("message", Required = Required.Always)]
        public string Message { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPNError(){}
        public ASPNError(ASPNError other) {
            Status = other.Status;
            Message = other.Message;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPNError ToASPNError() => new ASPNError(this);
        public bool Equals(ASPNError other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Status == other.Status
                && Message == other.Message;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ASPNError other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ASPNError);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Status);
            hashCode.Add(Message);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
