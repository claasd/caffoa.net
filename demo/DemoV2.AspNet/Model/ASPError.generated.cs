#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using DemoV2.AspNet.Model.Base;

namespace DemoV2.AspNet.Model {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class ASPError : IEquatable<ASPError> {
        public const string ASPErrorObjectName = "error";
        /// <summary>
        /// Single string based code describing the error.
        /// </summary>
        [JsonPropertyName("status")]
        [JsonRequired]
        public string Status { get; set; }

        /// <summary>
        /// Human readable error message.
        /// </summary>
        [JsonPropertyName("message")]
        [JsonRequired]
        public string Message { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public ASPError(){}
        public ASPError(ASPError other) {
            Status = other.Status;
            Message = other.Message;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public ASPError ToASPError() => new ASPError(this);
        public bool Equals(ASPError other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Status == other.Status
                && Message == other.Message;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ASPError other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ASPError);
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
