#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using DemoV2.Text.Json.Model.Base;

namespace DemoV2.Text.Json.Model {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class STJError : IEquatable<STJError> {
        public const string STJErrorObjectName = "error";
        /// <summary>
        /// Single string based code describing the error.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Human readable error message.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalProperties;

        public STJError(){}
        public STJError(STJError other) {
            Status = other.Status;
            Message = other.Message;
            AdditionalProperties = other.AdditionalProperties != null ? new Dictionary<string, object>(other.AdditionalProperties) : null;
        }
        public STJError ToSTJError() => new STJError(this);
        public bool Equals(STJError other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Status == other.Status
                && Message == other.Message;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(STJError other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as STJError);
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
